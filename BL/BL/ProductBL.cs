using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Accessors;
using DomainClasses.Models;

namespace BLL.BL
{
    public class ProductBL: IDisposable
    {
        private readonly ProductAccessor _productAccessor;

        public ProductBL()
        {
            _productAccessor = new ProductAccessor();
        }

        public List<Product> FindAll()
        {
            List<Product> catList;

            using (var productAccessor = new ProductAccessor())
            {
                catList = _productAccessor.Repo.All.ToList();
            }
            return catList;
        }

        public IQueryable<Product> GetAll()
        {
            IQueryable<Product> qCateogry;

            using (var productAccessor = new ProductAccessor())
            {
                qCateogry = productAccessor.Repo.All;
            }
            return qCateogry;
        }

        public bool Save(Product vo)
        {
            _productAccessor.Repo.InsertOrUpdate(vo);
            return _productAccessor.Save();
        }

        public Task<bool> SaveAsync(Product vo)
        {
            _productAccessor.Repo.InsertOrUpdate(vo);
            return Task.Run(() => _productAccessor.Save());            
        }

        public bool Remove(int id)
        {
            _productAccessor.Repo.Delete(id);
            return _productAccessor.Save();
        }

        public void Dispose()
        {
            _productAccessor.Dispose();
        }
    }
}
