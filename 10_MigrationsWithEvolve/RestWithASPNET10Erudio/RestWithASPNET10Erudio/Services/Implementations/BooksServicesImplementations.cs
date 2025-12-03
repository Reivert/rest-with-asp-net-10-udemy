using RestWithASPNET10Erudio.Model;
using RestWithASPNET10Erudio.Repositories;

namespace RestWithASPNET10Erudio.Services.Implementations
{
    public class BooksServicesImplementations : IBooksServices
    {
        private IBookRepository _repository;

        public BooksServicesImplementations(IBookRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public List<Books> FindAll()
        {
            return _repository.FindAll();
        }

        public Books FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Books Create(Books books)
        {
            return _repository.Create(books);
        }

        public Books Update(Books books)
        {
            return _repository.Update(books);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
