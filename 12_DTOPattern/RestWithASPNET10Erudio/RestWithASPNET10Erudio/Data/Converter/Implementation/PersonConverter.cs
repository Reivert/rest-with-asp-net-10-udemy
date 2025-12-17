using RestWithASPNET10Erudio.Data.Converter.Contract;
using RestWithASPNET10Erudio.Data.DTO;
using RestWithASPNET10Erudio.Model;

namespace RestWithASPNET10Erudio.Data.Converter.Implementation
{
    public class PersonConverter : IParser<PersonsDTO, Persons>, IParser<Persons, PersonsDTO>
    {
        public PersonsDTO Parse(Persons origin)
        {
            if (origin == null) return null;

            return new PersonsDTO
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public Persons Parse(PersonsDTO origin)
        {
            if (origin == null) return null;

            return new Persons
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public List<PersonsDTO> ParseList(List<Persons> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<Persons> ParseList(List<PersonsDTO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
