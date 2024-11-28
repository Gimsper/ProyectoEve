using Eve.Infraestructure.Base.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Eve.Infraestructure.Base
{
    public class _Repository : _IRepository { }

    public class _Repository<T> : _IRepository<T> where T : class
    {
        private readonly DbContext _context;

        public _Repository(DbContext context)
        {
            _context = context;
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetBy(Func<T, bool> func)
        {
            return _context.Set<T>().Where(func).First();
        }

        public List<T> GetListBy(Func<T, bool> func)
        {
            return _context.Set<T>().Where(func).ToList();
        }

        public T Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges() > 0 ? true : false;
        }

        public bool Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            return _context.SaveChanges() > 0 ? true : false;
        }
    }
}