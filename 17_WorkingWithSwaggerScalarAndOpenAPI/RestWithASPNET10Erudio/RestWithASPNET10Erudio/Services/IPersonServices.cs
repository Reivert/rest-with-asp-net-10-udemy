using RestWithASPNET10Erudio.Data.DTO.V1;

namespace RestWithASPNET10Erudio.Services
{
    public interface IPersonServices
    {

        PersonsDTO Create(PersonsDTO person);

        PersonsDTO FindById(long id);

        List<PersonsDTO> FindAll();

        PersonsDTO Update(PersonsDTO person);

        void Delete(long id);
    }
}
