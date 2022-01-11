using API.Core.Interfaces;
using API.Core.Models;
using API.Core.Specifications;
using API.Dtos;
using API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        private readonly IGenericRepository<ProductType> _productTypeRepository;
        private readonly IMapper _mapper;
        public ProductsController(IGenericRepository<Product> productRepository, IGenericRepository<ProductBrand> productBrandRepository, IGenericRepository<ProductType> productTypeRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _productBrandRepository = productBrandRepository;
            _productTypeRepository = productTypeRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductByIdAsync(ProductSpecParams productSpecParams)
        {
            var spec = new ProductsWithProduceTypeAndBrandsSpecification(productSpecParams);
            //return await _productRepository.GetEntityWithSpec(spec);
            var product = await _productRepository.GetEntityWithSpec(spec);
            return _mapper.Map<Product, ProductDto>(product);
        }
        /// <summary>
        /// All Product List
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult<Pagination<ProductDto>>> GetProducts(ProductSpecParams productSpecParams)
        {
            var spec = new ProductsWithProduceTypeAndBrandsSpecification(productSpecParams);

            var countSpec = new ProductWithFiltersForCountSpecification(productSpecParams);
            var totalItems = await _productRepository.CountAsync(spec);
            var products = await _productRepository.ListAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products);
             

            return Ok(new Pagination<ProductDto>(productSpecParams.PageIndex, productSpecParams.PageSize,totalItems,data));
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandRepository.ListAllAsync());
        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductTypes()
        {
            return Ok(await _productTypeRepository.ListAllAsync());
        }
    }
}
