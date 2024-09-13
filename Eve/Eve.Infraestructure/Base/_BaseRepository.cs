using Eve.Core.Context;
using Eve.Core.Entities;
using Eve.Infraestructure.Base.Interfaces;

namespace Eve.Infraestructure.Base
{
    public class _BaseRepository : _IBaseRepository { }

    public class _BaseRepository<T> : _BaseRepository, _IBaseRepository<T> where T : _BaseEntity
    {
        protected readonly EveContext _context;

        public _BaseRepository(EveContext context)
        {
            _context = context;
        }

        public List<T> GetAll()
        {
            var response = _context.Set<T>().ToList();
            return response;
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Where(x => x.Id == id).First();
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Update(T entity)
        {
            _context.Update(entity);
            return _context.SaveChanges() > 0 ? true : false;
        }

        public bool DeleteById(int id)
        {
            T entity = GetById(id);
            _context.Remove(entity);
            return _context.SaveChanges() > 0 ? true : false;
        }
    }
}
