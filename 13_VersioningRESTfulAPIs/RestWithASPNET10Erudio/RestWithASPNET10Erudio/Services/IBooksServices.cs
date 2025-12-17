using RestWithASPNET10Erudio.Model;

namespace RestWithASPNET10Erudio.Services
{
    public interface IBooksServices
    {
        Books Create(Books persons);
        Books Update(Books persons);
        void Delete(long id);
        Books FindById(long id);
        List<Books> FindAll();
    }
}
