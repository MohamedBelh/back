
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using store.Helper.Data;
using store.Models;
using store.Services.Contract;

namespace store.Services.Implementation
{
    public class ProduitService : IProduitService
    {
        private readonly StoreDbContext _context;
        public ProduitService(StoreDbContext context)
        {
            _context = context;
        }

        public async Task AddProduct(Product product)
        {
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _context.Products
              .Include(p => p.PPs)
              .FirstOrDefaultAsync(p => p.Id == id);

            if (product != null)
            {
                
                _context.photoProduits.RemoveRange(product.PPs);

                _context.Products.Remove(product);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.Include(p => p.PPs).ToListAsync();
        }

        public async Task<Product?> GetProductById(int id)
        {
            return await _context.Products.Include(p => p.PPs).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateProduct(int id, Product newProduct)
        {
            var existingProduct = await _context.Products.Include(p => p.PPs).FirstOrDefaultAsync(p => p.Id == id);

            if (existingProduct == null)
            {
                throw new KeyNotFoundException("Product not found");
            }

            
            existingProduct.Name = newProduct.Name;
            existingProduct.Description = newProduct.Description;
            existingProduct.QteStock = newProduct.QteStock;
            existingProduct.Prix = newProduct.Prix;

            
            _context.photoProduits.RemoveRange(existingProduct.PPs);
            existingProduct.PPs = newProduct.PPs;

           
            await _context.SaveChangesAsync();

        }
    }
}