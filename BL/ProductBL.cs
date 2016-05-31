using System.Collections.Generic;
using System.Linq;
using DAL.Accessors;
using DomainClasses.Models;

namespace BL
{
    public class ProductBL
    {
        private readonly ProductAccessor _categoryAccessor;

        public ProductBL()
        {
            _categoryAccessor = new ProductAccessor();
        }

        public List<Product> FindAll()
        {
            List<Product> catList;

            using (var categoryAccessor = new ProductAccessor())
            {
                catList = _categoryAccessor.Repo.All.ToList();
            }
            return catList;
        }

        public IQueryable<Product> GetAll()
        {
            IQueryable<Product> qCateogry;

            using (var categoryAccessor = new ProductAccessor())
            {
                qCateogry = categoryAccessor.Repo.All;
            }
            return qCateogry;
        }

        public bool Save(Product vo)
        {
            _categoryAccessor.Repo.InsertOrUpdate(vo);
            return _categoryAccessor.Save();
        }

        public bool Remove(int id)
        {
            _categoryAccessor.Repo.Delete(id);
            return _categoryAccessor.Save();
        }
    }
}
