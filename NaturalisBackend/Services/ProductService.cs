using Microsoft.EntityFrameworkCore;
using NaturalisBackend.Database;
using NaturalisBackend.Models;

namespace NaturalisBackend.Services
{

    public class ProductService
    {
        private readonly NaturalisContext _context;
        public ProductService(NaturalisContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts()
        {

            return _context.Produtos.Include(p => p.ProductTypeNavigation).ToList();
        }
    }
}
