
using Microsoft.EntityFrameworkCore;
using RestWithASPNET10Erudio.Model.Base;
using RestWithASPNET10Erudio.Model.Context;

namespace RestWithASPNET10Erudio.Repositories.Implementations
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MSSQLContext _context;
        private DbSet<T> _dataset;

        public GenericRepository(MSSQLContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dataset = _context.Set<T>();
        }

        public T FindById(long id)
        {
            return _dataset.Find(id);
        }

        public List<T> FindAll()
        {
            return _dataset.AsNoTracking().ToList();
        }
        public T Create(T item)
        {
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }

        public T Update(T item)
        {
            var existeItem = _dataset.Find(item.Id);

            if (existeItem == null)
                return null;

            _context.Entry(existeItem).CurrentValues.SetValues(item);
            _context.SaveChanges();

            return existeItem;
        }

        public void Delete(long id)
        {
            var existeItem = _dataset.Find(id);

            if (existeItem == null)
                return;

            _context.Remove(existeItem);
            _context.SaveChanges();
        }

        public bool Exists(long id)
        {
            return _dataset.Any(e => e.Id == id);
        }

    }
}
