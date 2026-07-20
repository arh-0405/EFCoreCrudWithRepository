using CrudOperationWithRepo.Models;

namespace CrudOperationWithRepo.Services
{
    public interface IProductService
    {
        //Get all Products
        IEnumerable<Product> GetAllProducts();
        
        //Get a Product by Id
        Product GetById(int id);//, string name)

        //Create a new Product
        void Create(Product product);
        void Update(Product product);
        void Delete(int id);
        //Product GetProductByName(string name);
        //throws err [modification not allowed]
    }
}
//Open/Closed Principle (OCP)
//A class should be open for extension but closed for modification.
//This means that we should be able to add new functionality to a class without modifying its existing code.