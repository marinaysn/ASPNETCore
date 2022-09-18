using MarkaBookStore.DataAccess.Repository.IRepository;
using MarkaBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MarkaBookStore.DataAccess.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private ApplicationDBContext _db;

        public CoverTypeRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        // //Use in UnitOfWork method
        //public void Save()
        //{
        //    _db.SaveChanges();
        //}

        public void Update(CoverType obj)
        {
            _db.CoverTypes.Update(obj);
        }
    }
}
