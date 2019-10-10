using ECommerce.Context;
using ECommerce.Model;
using ECommerce.Service.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.DataService
{
    public class Product : IProduct
    {
        private readonly CoreDB _db;
        private readonly IServiceScope _scope;


        public Product(IServiceProvider services)
        {
            _scope = services.CreateScope();
            _db = _scope.ServiceProvider.GetRequiredService<CoreDB>();
        }

        public async Task<bool> Add(ProductModel product)
        {
            var success = false;

            _db.Product.Add(product);

            var numberOfItemsCreated = await _db.SaveChangesAsync();

            if (numberOfItemsCreated == 1)
                success = true;

            return success;
        }

        public ProductModel GetByProductCode(int productCode)
        {
            return _db.Product.SingleOrDefault(x => x.ProductCode == productCode);
        }

        IOrderedQueryable<ProductModel> IProduct.GetAll()
        {
            var result = _db.Product.OrderByDescending(x => x.Price);
            return result;
        }
    }
}
