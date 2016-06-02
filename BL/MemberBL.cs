using System.Collections.Generic;
using System.Linq;
using DAL.Accessors;
using DomainClasses.Models;

namespace BL
{
    public class MemberBL
    {
        private readonly MemberAccessor _memberAccessor;

        public MemberBL()
        {
            _memberAccessor = new MemberAccessor();
        }

        public List<Member> FindAll()
        {
            List<Member> catList;

            using (var memberAccessor = new MemberAccessor())
            {
                catList = _memberAccessor.Repo.All.ToList();
            }
            return catList;
        }

        public IQueryable<Member> GetAll()
        {
            IQueryable<Member> qCateogry;

            using (var memberAccessor = new MemberAccessor())
            {
                qCateogry = memberAccessor.Repo.All;
            }
            return qCateogry;
        }

        public bool Save(Member vo)
        {
            _memberAccessor.Repo.InsertOrUpdate(vo);
            return _memberAccessor.Save();
        }

        public bool Remove(int id)
        {
            _memberAccessor.Repo.Delete(id);
            return _memberAccessor.Save();
        }
    }
}
