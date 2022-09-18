using MarkaBookStore.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkaBookStore.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository Cat { get; private set; }

        public ICoverTypeRepository Cov { get; private set; }

        private ApplicationDBContext _db;

        public UnitOfWork(ApplicationDBContext db)
        {
            _db = db;
            Cat = new CategoryRepository(_db);

            Cov = new CoverTypeRepository(_db);
        }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
