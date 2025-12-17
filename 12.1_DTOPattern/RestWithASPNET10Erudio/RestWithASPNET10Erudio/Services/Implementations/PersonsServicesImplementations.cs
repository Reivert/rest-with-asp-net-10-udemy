using RestWithASPNET10Erudio.Data.Converter.Implementation;
using RestWithASPNET10Erudio.Data.DTO;
using RestWithASPNET10Erudio.Model;
using RestWithASPNET10Erudio.Repositories;

namespace RestWithASPNET10Erudio.Services.Implementations
{
    public class PersonsServicesImplementations : IPersonsServices
    {
        private IRepository<Persons> _repository;
        private readonly PersonConverter _converter;

        public PersonsServicesImplementations(IRepository<Persons> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _converter = new PersonConverter();
        }

        public List<PersonsDTO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public PersonsDTO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }        

        public PersonsDTO Create(PersonsDTO persons)
        {
            var entity = _converter.Parse(persons);
            entity = _repository.Create(entity);
            return _converter.Parse(entity);
        }

        public PersonsDTO Update(PersonsDTO persons)
        {
            var entity = _converter.Parse(persons);
            entity = _repository.Update(entity);
            return _converter.Parse(entity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }        
    }
}
