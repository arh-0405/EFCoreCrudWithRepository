using CrudOperationWithRepo.Models;
using CrudOperationWithRepo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudOperationWithRepo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        //GET: api/Product/GeAllProducts
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }
        //GET: api/Product/GetById/5
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound("Product not found");
            }
            return Ok(product);
        }
        //POST: api/Product/Add
        [HttpPost("Add")]
        public IActionResult Add(Product product)
        {
            if (product == null)
            {
                return BadRequest("Product is null");
            }
            _productService.Create(product);
            return Ok("Product added successfully");
        }
        //PUT: api/Product/Update/5
        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, Product product)
        {
            if (product == null)
            {
                return BadRequest("Product is null");
            }
            var existingProduct = _productService.GetById(id);
            if (existingProduct == null)
            {
                return NotFound("Product not found");
            }
            _productService.Update(product);
            return Ok("Product updated successfully");
        }
        //DELETE: api/Product/Delete/5
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound("Product not found");
            }
            _productService.Delete(id);
            return Ok("Product deleted successfully");
        }
    }
}
//Dependency Inversion Principle (DIP)
//A design pattern & programming technique that helps acheive Loose Coupling between classes and their dependencies. 
//Instead of creating class & dependencies on its own, those are provided from an external source through constructor or method or interface.

//Command and Query Architecture (CQRS)