using System;
using System.Linq;
using System.Linq.Expressions;
using DAL.Contexts;
using DAL.Repositories.IRepo;
using System.Data.Entity;
using DAL.Base;
using DomainClasses.Models;

namespace DAL.Repositories
{
    public class PTypeRepo : IPTypeRepo
    {
        private readonly MEContext _context;
        public PTypeRepo(IUnitOfWork uow)
        {
            _context = uow.Context as MEContext;
        }

        public IQueryable<ProductType> All
        {
            get
            {
                return _context.ProductTypes;
            }
        }

        public IQueryable<ProductType> AllIncluding(params Expression<Func<ProductType, object>>[] includeProperties)
        {
            IQueryable<ProductType> query = _context.ProductTypes;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public void Delete(int id)
        {
            var category = _context.ProductTypes.Find(id);
            _context.ProductTypes.Remove(category);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public ProductType Find(int id)
        {
            return _context.ProductTypes.Find(id);
        }

        public void InsertOrUpdate(ProductType category)
        {
            if (category.ProductTypeID == default(int))
            {
                _context.SetAdd(category);
            }
            else
            {
                _context.SetModified(category);
            }
        }
        public void InsertOrUpdateGraph(ProductType customerGraph)
        {         
        }
    }
}
