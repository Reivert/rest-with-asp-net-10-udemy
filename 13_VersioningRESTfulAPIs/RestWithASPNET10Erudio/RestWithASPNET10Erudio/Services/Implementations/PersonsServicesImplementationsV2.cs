using RestWithASPNET10Erudio.Data.Converter.Implementation;
using RestWithASPNET10Erudio.Data.DTO.V1;
using RestWithASPNET10Erudio.Model;
using RestWithASPNET10Erudio.Repositories;

namespace RestWithASPNET10Erudio.Services.Implementations
{
    public class PersonsServicesImplementationsV2
    {
        private IRepository<Persons> _repository;
        private readonly PersonConverter _converter;

        public PersonsServicesImplementationsV2(IRepository<Persons> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }


        public PersonsDTO Create(PersonsDTO person)
        {
            var entity = _converter.Parse(person);
            entity = _repository.Create(entity);
            return _converter.Parse(entity);
        }
    }
}
