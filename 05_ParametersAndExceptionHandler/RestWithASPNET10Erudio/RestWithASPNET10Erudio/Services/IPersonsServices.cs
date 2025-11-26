using RestWithASPNET10Erudio.Model;

namespace RestWithASPNET10Erudio.Services
{
    public interface IPersonsServices
    {
        Persons Create(Persons persons);
        Persons Update(Persons persons);
        void Delete(long id);
        Persons FindById(int id);
        List<Persons> FindAll();       
    }
}
