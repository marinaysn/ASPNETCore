using MarkaBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MarkaBookStore.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class

    {
        // T - Category
        IEnumerable<T> GetAll(); //IEnumerable<Category> obj = _db.Categories;
        void Add(T entity); // _db.Categories.Add(obj);

        T GetById(int id);

        T GetFirstOrDefault(Expression<Func<T, bool>> filter); //_db.Categories.FirstOrDefault(x => x.Name == "id");

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entityList);
    }
}
