using System;
using DAL.Contexts;
using DAL.Repositories;
using DAL.UOW;

namespace DAL.Accessors
{
    public class PTypeAccessor : IDisposable
    {
        private readonly MEUOW<MEContext> _uow;
        private readonly PTypeRepo _repo;

        public PTypeAccessor()
        {
            _uow = new MEUOW<MEContext>();
            _repo = new PTypeRepo(_uow);
        }

        public PTypeRepo Repo
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