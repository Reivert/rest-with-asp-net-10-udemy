using RestWithASPNET10Erudio.Data.Converter.Contract;
using RestWithASPNET10Erudio.Data.DTO.V2;
using RestWithASPNET10Erudio.Model;

namespace RestWithASPNET10Erudio.Data.Converter.Implementation
{
    public class PersonConverter : IParser<PersonsDTO, Persons>, IParser<Persons, PersonsDTO>
    {
        public Persons Parse(PersonsDTO origin)
        {
            if (origin == null) return null;
            return new Persons
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender,
                // BirthDay = origin.BirthDay
            };
        }

        public PersonsDTO Parse(Persons origin)
        {
            if (origin == null) return null;
            return new PersonsDTO
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender,
                BirthDay = DateTime.Now
                // Mocking a birthday since the Person entity does not have this field.
                //BirthDay = origin.BirthDay ?? DateTime.Now
            };
        }

        public List<Persons> ParseList(List<PersonsDTO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<PersonsDTO> ParseList(List<Persons> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
