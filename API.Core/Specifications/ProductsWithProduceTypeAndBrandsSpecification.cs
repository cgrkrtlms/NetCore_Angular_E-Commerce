using API.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace API.Core.Specifications
{
   public class ProductsWithProduceTypeAndBrandsSpecification:BaseSpecification<Product>
    {
        public ProductsWithProduceTypeAndBrandsSpecification(ProductSpecParams productSpecParams)
            :base(x=>
            (string.IsNullOrWhiteSpace(productSpecParams.Search) || x.Name.ToLower().Contains(productSpecParams.Search))
            &&
            (!productSpecParams.BrandId.HasValue ||x.ProductBrandId == productSpecParams.BrandId) 
            &&
            (!productSpecParams.TypeId.HasValue || x.ProductTypeId== productSpecParams.TypeId)
            )
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
            //AddOrderBy(x=>x.Name);

            ApplyPaging(productSpecParams.PageSize * (productSpecParams.PageIndex - 1), productSpecParams.PageSize);


            if (!string.IsNullOrWhiteSpace(productSpecParams.Sort))
            {
                switch (productSpecParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(x=>x.Name);
                        break;
                }
            }
        }
        public ProductsWithProduceTypeAndBrandsSpecification(int id):base(x=>x.ID==id)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
    }
}
