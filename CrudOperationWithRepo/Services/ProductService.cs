using CrudOperationWithRepo.Models;

namespace CrudOperationWithRepo.Services
{
    //Here we write all the business logic of the application
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Create(Product product)
        {
            // Ensure database generates the identity value instead of using any client-supplied Id
            product.Id = 0;
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var existingProduct = _context.Products.Find(id);
            if (existingProduct != null)
            {
                _context.Products.Remove(existingProduct);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetById(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            return product;
        }

        public void Update(Product product)
        {
            //throw new NotImplementedException();
            var existingProduct = _context.Products.Find(product.Id);
            if (existingProduct != null)
            {
               existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                _context.SaveChanges();
            }
        }
    }
}
//Encapsulation : Wrapping up of Data and Method into a single class