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
    public class ProductRepo : IProductRepo
    {
        private readonly MEContext _context;
        public ProductRepo(IUnitOfWork uow)
        {
            _context = uow.Context as MEContext;
        }

        public IQueryable<Product> All
        {
            get
            {
                return _context.Products;
            }
        }
        //public List<Customer> AllCustomers
        //{
        //    get { return _context.Customers.ToList(); }
        //}
        //public List<Customer> AllCustomersWhoHaveOrdered
        //{
        //    get { return _context.Customers.Where(c => c.Orders.Any()).ToList(); }
        //}

        public IQueryable<Product> AllIncluding(params Expression<Func<Product, object>>[] includeProperties)
        {
            IQueryable<Product> query = _context.Products;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public void Delete(int id)
        {
            var category = _context.Products.Find(id);
            _context.Products.Remove(category);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Product Find(int id)
        {
            return _context.Products.Find(id);
        }

        public void InsertOrUpdate(Product category)
        {
            if (category.ProductID == default(int))
            {
                _context.SetAdd(category);
            }
            else
            {
                _context.SetModified(category);
            }
        }
        public void InsertOrUpdateGraph(Product customerGraph)
        {
            //if (customerGraph.State == State.Added)
            //{
            //    _context.Products.Add(customerGraph);
            //}
            //else
            //{
            //    _context.Products.Add(customerGraph);
            //    _context.ApplyStateChanges();
            //}
        }
    }
}
//For references objects
//public IQueryable<ProductReference> Products
//{
//    get { return _context.Products.AsNoTracking(); }
//}
//public IQueryable<CustomerReference> Customers
//{
//    get { return _context.Customers.AsNoTracking(); }
//}