using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _categoryContext;
        
        public ProductRepository(ApplicationDbContext context)
        {
            _categoryContext = context;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetProductCategoryAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}