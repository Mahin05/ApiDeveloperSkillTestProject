using API.Model;
using ApiDeveloperSkillTestProject.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ApiDeveloperSkillTestProject.Controllers.API
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public ProductController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Product
        [Route("GetAllProducts")]
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var allProducts = await _context.products.ToListAsync();

            if (allProducts == null || !allProducts.Any())
            {
                return NotFound("products not found.");
            }

            return Ok(new {success=true,message="data loaded successfully",data= allProducts });
        }


        // GET: Product/Details/5
        [Route("GetProduct")]
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productModel = await _context.products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productModel == null)
            {
                return NotFound();
            }

            return Ok(new { success = true, message = "data loaded successfully", data = productModel });
        }

        // POST: Product/Create
        [Route("CreateProduct")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productModel);
                await _context.SaveChangesAsync();

                return Ok(new {success = true, message = "Product created successfully",data = productModel});
            }

            return BadRequest(new {success = false,message = "Invalid product data"});
        }

        [Route("EditProduct")]
        [HttpPut]
        public async Task<IActionResult> Edit(int id,[FromBody] ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                if (id != 0)
                {
                    _context.Update(productModel);
                    await _context.SaveChangesAsync();

                    return Ok(new { success = true, message = "Product updated successfully", data = productModel });
                }
            }

            return BadRequest(new {success = false,message = "Invalid product data"});
        }

        // POST: Product/Delete/5
        [Route("Delete")]
        [HttpDelete]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productModel = await _context.products.FindAsync(id);
            if (productModel != null)
            {
                _context.products.Remove(productModel);
            }

            await _context.SaveChangesAsync();
            return Ok(new {success=true, message = "Product deleted successfully!" });
        }
    }
}
