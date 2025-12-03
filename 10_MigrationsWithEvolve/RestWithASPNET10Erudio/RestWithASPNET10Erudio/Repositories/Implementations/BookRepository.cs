using Microsoft.EntityFrameworkCore;
using RestWithASPNET10Erudio.Model;
using RestWithASPNET10Erudio.Model.Context;

namespace RestWithASPNET10Erudio.Repositories.Implementations
{
    public class BookRepository : IBookRepository
    {
        private MSSQLContext _context;

        public BookRepository(MSSQLContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<Books> FindAll()
        {
            return _context.Books.AsNoTracking().ToList();
        }

        public Books FindById(long id)
        {
            return _context.Books.Find(id);
        }

        public Books Create(Books books)
        {
            _context.Books.Add(books);
            _context.SaveChanges();
            return books;
        }

        public Books Update(Books books)
        {
            var existeBook = _context.Books.Find(books.Id);

            if (existeBook == null)
                return null;

            _context.Entry(existeBook).CurrentValues.SetValues(books);
            _context.SaveChanges();

            return existeBook;
        }

        public void Delete(long id)
        {
            var existeBook = _context.Books.Find(id);

            if (existeBook == null)
                return;

            _context.Remove(existeBook);
            _context.SaveChanges();
        }
    }
}
