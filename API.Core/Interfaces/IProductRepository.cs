using API.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Core.Interfaces
{
  public  interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        /// <summary>
        /// All Product List
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyList<Product>> GetProductAsync();
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
    }
}
