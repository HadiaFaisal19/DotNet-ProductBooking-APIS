using Admin.Data;
using Admin.Models;
using Admin.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        public ProductsController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            
        }

        [HttpGet]
        public IActionResult GetAllProducts() 
        {
            return Ok(dbContext.Products.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetProductById(Guid id) 
        {
            var product = dbContext.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult AddProduct(AddProductDto addProductDto) 
        {
            var productEntity = new Product()
            {
                Name = addProductDto.Name,
                Category = addProductDto.Category,
                Brand = addProductDto.Brand,
                Price = addProductDto.Price,
                IsAvailable = addProductDto.IsAvailable,
                Quantity = addProductDto.Quantity,
                Description= addProductDto.Description
            };
            dbContext.Products.Add(productEntity);
            dbContext.SaveChanges();

            return Ok(productEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]

        public IActionResult UpdateProduct(Guid id, UpdateProductDto updateProductDto)
        {
            var product = dbContext.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            product.Name = updateProductDto.Name;
            product.Category = updateProductDto.Category;
            product.Brand = updateProductDto.Brand;     
            product.Price = updateProductDto.Price;
            product.IsAvailable = updateProductDto.IsAvailable;
            product.Quantity = updateProductDto.Quantity;
            product.Description = updateProductDto.Description;
            dbContext.SaveChanges();
            return Ok(product);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteProduct(Guid id)
        {
            var product = dbContext.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            

            dbContext.Products.Remove(product);
            dbContext.SaveChanges();
            return Ok(product);
        }
    }
}
