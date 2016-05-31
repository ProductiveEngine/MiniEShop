using System;
using DAL.Contexts;
using DAL.Repositories;
using DAL.UOW;

namespace DAL.Accessors
{
    public class ProductAccessor : IDisposable
    {
        private readonly MEUOW<MEContext> _uow;
        private readonly ProductRepo _repo;

        public ProductAccessor()
        {
            _uow = new MEUOW<MEContext>();
            _repo = new ProductRepo(_uow);
        }

        public ProductRepo Repo
        {
            get { return _repo;}
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