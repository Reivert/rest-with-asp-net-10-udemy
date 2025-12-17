using RestWithASPNET10Erudio.Data.DTO;

namespace RestWithASPNET10Erudio.Services
{
    public interface IBooksServices
    {
        BooksDTO Create(BooksDTO books);
        BooksDTO Update(BooksDTO books);
        void Delete(long id);
        BooksDTO FindById(long id);
        List<BooksDTO> FindAll();
    }
}
