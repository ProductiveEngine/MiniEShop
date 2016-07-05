using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Accessors;
using DomainClasses.Models;

namespace BLL.BL
{
    public class PTypeBL : IDisposable
    {
        private readonly PTypeAccessor _PTypeAccessor;

        public PTypeBL()
        {
            _PTypeAccessor = new PTypeAccessor();
        }

        public List<ProductType> FindAll()
        {
            List<ProductType> catList;

            using (var PTypeAccessor = new PTypeAccessor())
            {
                catList = _PTypeAccessor.Repo.All.ToList();
            }
            return catList;
        }

        public IQueryable<ProductType> GetAll()
        {
            IQueryable<ProductType> qCateogry;

            using (var PTypeAccessor = new PTypeAccessor())
            {
                qCateogry = PTypeAccessor.Repo.All;
            }
            return qCateogry;
        }

        public bool Save(ProductType vo)
        {
            _PTypeAccessor.Repo.InsertOrUpdate(vo);
            return _PTypeAccessor.Save();
        }

        public Task<bool> SaveAsync(ProductType vo)
        {
            _PTypeAccessor.Repo.InsertOrUpdate(vo);
            return Task.Run(() => _PTypeAccessor.Save());
        }

        public bool Remove(int id)
        {
            _PTypeAccessor.Repo.Delete(id);
            return _PTypeAccessor.Save();
        }

        public void Dispose()
        {
            _PTypeAccessor.Dispose();
        }
    }
}
