using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BLL.BL;
using DomainClasses.Models;
using MiniEShop.Models;

namespace MiniEShop.Controllers.Api
{
    [AllowAnonymous]
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {        
        private readonly ProductBL _productBl = new ProductBL();

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

        [Route("getProducts/filtered/{nameFilter}")]
        public IQueryable<Product> GetProductsFiltered(string nameFilter)
        {

            IQueryable<Product> qProd;
            try
            {
                qProd = _productBl.GetAll().Where(a => a.ProductName.Contains(nameFilter));
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
            Product product = await _productBl.GetAll().FirstOrDefaultAsync(x => x.ProductID == id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);

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

            try
            {
                   product.ProductType = null;
                   await _productBl.SaveAsync(product);
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
            bool ok = await _productBl.SaveAsync(product);
                        
            return CreatedAtRoute("DefaultApi", new { id = product.ProductID }, product);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> DeleteProduct(int id)
        {
            Product product = await _productBl.GetAll().FirstOrDefaultAsync(x => x.ProductID == id);

            if (!_productBl.Remove(id))
            {
                return NotFound();
            }
                        
            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _productBl.Dispose();                
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return _productBl.GetAll().Count(e => e.ProductID == id) > 0;
        }
    }
}