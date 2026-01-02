using RestWithASPNET10Erudio.Data.DTO.V1;
using RestWithASPNET10Erudio.Model;

namespace RestWithASPNET10Erudio.Services
{
    public interface IBookServices
    {

        BooksDTO Create(BooksDTO book);

        BooksDTO FindById(long id);

        List<BooksDTO> FindAll();

        BooksDTO Update(BooksDTO book);

        void Delete(long id);
    }
}
