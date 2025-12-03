using RestWithASPNET10Erudio.Model;

namespace RestWithASPNET10Erudio.Repositories
{
    public interface IBookRepository
    {
        Books Create(Books books);
        Books Update(Books books);
        void Delete(long id);
        Books FindById(long id);
        List<Books> FindAll();
    }
}
