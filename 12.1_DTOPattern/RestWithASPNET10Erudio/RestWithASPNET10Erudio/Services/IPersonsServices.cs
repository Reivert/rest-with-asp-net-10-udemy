using RestWithASPNET10Erudio.Data.DTO;

namespace RestWithASPNET10Erudio.Services
{
    public interface IPersonsServices
    {
        PersonsDTO Create(PersonsDTO persons);
        PersonsDTO Update(PersonsDTO persons);
        void Delete(long id);
        PersonsDTO FindById(long id);
        List<PersonsDTO> FindAll();       
    }
}
