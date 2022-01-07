using API.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace API.Core.Specifications
{
   public class ProductsWithProduceTypeAndBrandsSpecification:BaseSpecification<Product>
    {
        public ProductsWithProduceTypeAndBrandsSpecification()
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
        public ProductsWithProduceTypeAndBrandsSpecification(int id):base(x=>x.ID==id)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
    }
}
