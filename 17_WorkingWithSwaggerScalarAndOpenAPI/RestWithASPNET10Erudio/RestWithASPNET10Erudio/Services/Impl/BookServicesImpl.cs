using Mapster;
using RestWithASPNET10Erudio.Data.DTO.V1;
using RestWithASPNET10Erudio.Model;
using RestWithASPNET10Erudio.Repositories;

namespace RestWithASPNET10Erudio.Services.Impl
{
    public class BookServicesImpl : IBookServices
    {
        private IRepository<Books> _repository;

        public BookServicesImpl(IRepository<Books> repository)
        {
            _repository = repository;
        }

        public List<BooksDTO> FindAll()
        {
            return _repository.FindAll().Adapt<List<BooksDTO>>();
        }

        public BooksDTO FindById(long id)
        {
            return _repository.FindById(id).Adapt<BooksDTO>();
        }

        public BooksDTO Create(BooksDTO book)
        {
            var entity = book.Adapt<Books>();
            entity = _repository.Create(entity);
            return entity.Adapt<BooksDTO>();
        }

        public BooksDTO Update(BooksDTO book)
        {
            var entity = book.Adapt<Books>();
            entity = _repository.Update(entity);
            return entity.Adapt<BooksDTO>();
        }
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}