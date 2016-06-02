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
    public class MemberRepo : IMemberRepo
    {
        private readonly MEContext _context;
        public MemberRepo(IUnitOfWork uow)
        {
            _context = uow.Context as MEContext;
        }

        public IQueryable<Member> All
        {
            get
            {
                return _context.Members;
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

        public IQueryable<Member> AllIncluding(params Expression<Func<Member, object>>[] includeProperties)
        {
            IQueryable<Member> query = _context.Members;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public void Delete(int id)
        {
            var category = _context.Members.Find(id);
            _context.Members.Remove(category);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Member Find(int id)
        {
            return _context.Members.Find(id);
        }

        public void InsertOrUpdate(Member category)
        {
            if (category.MemberID == default(int))
            {
                _context.SetAdd(category);
            }
            else
            {
                _context.SetModified(category);
            }
        }
        public void InsertOrUpdateGraph(Member customerGraph)
        {
            //if (customerGraph.State == State.Added)
            //{
            //    _context.Members.Add(customerGraph);
            //}
            //else
            //{
            //    _context.Members.Add(customerGraph);
            //    _context.ApplyStateChanges();
            //}
        }
    }
}
//For references objects
//public IQueryable<MemberReference> Members
//{
//    get { return _context.Members.AsNoTracking(); }
//}
//public IQueryable<CustomerReference> Customers
//{
//    get { return _context.Customers.AsNoTracking(); }
//}