using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using API.Model;
using ApiDeveloperSkillTestProject.Data;

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
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var productModel = await _context.products
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (productModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(productModel);
        //}

        // GET: Product/Create
        //public IActionResult Create()
        //{
        //    return Ok();
        //}

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

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


        // GET: Product/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var productModel = await _context.products.FindAsync(id);
        //    if (productModel == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(productModel);
        //}

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price")] ProductModel productModel)
        //{
        //    if (id != productModel.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(productModel);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ProductModelExists(productModel.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return Ok(productModel);
        //}

        // GET: Product/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var productModel = await _context.products
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (productModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(productModel);
        //}

        // POST: Product/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var productModel = await _context.products.FindAsync(id);
        //    if (productModel != null)
        //    {
        //        _context.products.Remove(productModel);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ProductModelExists(int id)
        //{
        //    return _context.products.Any(e => e.Id == id);
        //}
    }
}
