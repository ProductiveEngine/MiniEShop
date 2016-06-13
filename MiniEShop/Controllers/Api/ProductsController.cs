using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BL;
using DomainClasses.Models;
using MiniEShop.Models;

namespace MiniEShop.Controllers.Api
{
    public class ProductsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ProductBL _productBl = new ProductBL();

        // GET: api/Products
        public IQueryable<Product> GetProducts()
        {

            IQueryable<Product> qProd;
            try
            {
                qProd = _productBl.GetAll();
            }
            catch (Exception ex)
            {
                qProd = null;
            }
            return qProd;
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> GetProduct(int id)
        {
            //Product product = await db.Products.FindAsync(id);
            //if (product == null)
            //{
            //    return NotFound();
            //}

            //return Ok(product);
            return Ok();
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductID)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //db.Products.Add(product);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = product.ProductID }, product);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> DeleteProduct(int id)
        {
            Product product = null;// await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            //db.Products.Remove(product);
            await db.SaveChangesAsync();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return true;// db.Products.Count(e => e.ProductID == id) > 0;
        }
    }
}