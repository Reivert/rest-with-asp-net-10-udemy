using RestWithASPNET10Erudio.Model;

namespace RestWithASPNET10Erudio.Repositories
{
    public interface IPersonRepository
    {
        Persons Create(Persons persons);
        Persons Update(Persons persons);
        void Delete(long id);
        Persons FindById(long id);
        List<Persons> FindAll();
    }
}
