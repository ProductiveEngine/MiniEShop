using System;
using DAL.Contexts;
using DAL.Repositories;
using DAL.UOW;

namespace DAL.Accessors
{
    public class MemberAccessor : IDisposable
    {
        private readonly MEUOW<MEContext> _uow;
        private readonly MemberRepo _repo;

        public MemberAccessor()
        {
            _uow = new MEUOW<MEContext>();
            _repo = new MemberRepo(_uow);
        }

        public MemberRepo Repo
        {
            get { return _repo; }
        }

        public bool Save()
        {
            return _uow.Save() > -1;
        }

        public void Dispose()
        {
        }
    }
}