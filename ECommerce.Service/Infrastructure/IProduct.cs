using ECommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.Infrastructure
{
    public interface IProduct
    {
        Task<bool> Add(ProductModel product);
        IOrderedQueryable<ProductModel> GetAll();
        ProductModel GetByProductCode(int productCode);
    }
}
