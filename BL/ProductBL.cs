using System.Collections.Generic;
using System.Linq;
using DAL.Accessors;
using DomainClasses.Models;

namespace BL
{
    public class ProductBL
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

        public bool Remove(int id)
        {
            _productAccessor.Repo.Delete(id);
            return _productAccessor.Save();
        }
    }
}
