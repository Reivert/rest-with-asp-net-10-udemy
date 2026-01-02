using RestWithASPNET10Erudio.Data.Converter.Impl;
using RestWithASPNET10Erudio.Data.DTO.V2;
using RestWithASPNET10Erudio.Model;
using RestWithASPNET10Erudio.Repositories;

namespace RestWithASPNET10Erudio.Services.Impl
{
    public class PersonServicesImplV2
    {

        private IRepository<Persons> _repository;
        private readonly PersonConverter _converter;

        public PersonServicesImplV2(IRepository<Persons> repository)
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
