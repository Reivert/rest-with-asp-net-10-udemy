using Mapster;
using RestWithASPNET10Erudio.Data.DTO;
using RestWithASPNET10Erudio.Model;
using RestWithASPNET10Erudio.Repositories;

namespace RestWithASPNET10Erudio.Services.Implementations
{
    public class BooksServicesImplementations : IBooksServices
    {
        private IRepository<Books> _repository;

        public BooksServicesImplementations(IRepository<Books> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public List<BooksDTO> FindAll()
        {
            return _repository.FindAll().Adapt<List<BooksDTO>>();
        }

        public BooksDTO FindById(long id)
        {
            return _repository.FindById(id).Adapt<BooksDTO>();
        }

        public BooksDTO Create(BooksDTO books)
        {
            var entity = books.Adapt<Books>();
            entity = _repository.Create(entity);
            return entity.Adapt<BooksDTO>();
        }

        public BooksDTO Update(BooksDTO books)
        {
            var entity = books.Adapt<Books>();
            entity = _repository.Update(entity);
            return entity.Adapt<BooksDTO>();
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
