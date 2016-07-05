using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BLL.BL;
using DomainClasses.Models;
using MiniEShop.Models;

namespace MiniEShop.Controllers.Api
{
    public class ProductTypesController : ApiController
    {
        private readonly PTypeBL _pTypeBl = new PTypeBL();

        // GET: api/ProductTypes
        public IQueryable<ProductType> GetProductTypes()
        {
            IQueryable<ProductType> qPType;
            try
            {
                qPType = _pTypeBl.GetAll();
            }
            catch (Exception ex)
            {
                qPType = null;
            }
            return qPType;
        }

        // GET: api/ProductTypes/5
        [ResponseType(typeof(ProductType))]
        public async Task<IHttpActionResult> GetProductType(int id)
        {
            ProductType productType = await _pTypeBl.GetAll().FirstOrDefaultAsync(x => x.ProductTypeID == id);

            if (productType == null)
            {
                return NotFound();
            }

            return Ok(productType);
        }

        // PUT: api/ProductTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProductType(int id, ProductType productType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productType.ProductTypeID)
            {
                return BadRequest();
            }            

            try
            {
                await _pTypeBl.SaveAsync(productType);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductTypeExists(id))
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

        // POST: api/ProductTypes
        [ResponseType(typeof(ProductType))]
        public async Task<IHttpActionResult> PostProductType(ProductType productType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool ok = await _pTypeBl.SaveAsync(productType);

            return CreatedAtRoute("DefaultApi", new { id = productType.ProductTypeID }, productType);
        }

        // DELETE: api/ProductTypes/5
        [ResponseType(typeof(ProductType))]
        public async Task<IHttpActionResult> DeleteProductType(int id)
        {
            ProductType productType = await _pTypeBl.GetAll().FirstOrDefaultAsync(x => x.ProductTypeID == id);
            if (productType == null)
            {
                return NotFound();
            }
           
            return Ok(productType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _pTypeBl.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductTypeExists(int id)
        {
            return _pTypeBl.GetAll().Count(e => e.ProductTypeID == id) > 0;
        }
    }
}