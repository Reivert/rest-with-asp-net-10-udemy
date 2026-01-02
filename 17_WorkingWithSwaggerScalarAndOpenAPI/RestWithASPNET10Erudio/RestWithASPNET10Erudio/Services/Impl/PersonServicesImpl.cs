using Mapster;
using RestWithASPNET10Erudio.Data.DTO.V1;
using RestWithASPNET10Erudio.Model;
using RestWithASPNET10Erudio.Repositories;

namespace RestWithASPNET10Erudio.Services.Impl
{
    public class PersonServicesImpl : IPersonServices
    {

        private IRepository<Persons> _repository;
        public PersonServicesImpl(IRepository<Persons> repository)
        {
            _repository = repository;
        }

        public List<PersonsDTO> FindAll()
        {
            return _repository.FindAll().Adapt<List<PersonsDTO>>();
        }

        public PersonsDTO FindById(long id)
        {
            return _repository.FindById(id).Adapt<PersonsDTO>();
        }

        public PersonsDTO Create(PersonsDTO person)
        {
            var entity = person.Adapt<Persons>();
            entity = _repository.Create(entity);
            return entity.Adapt<PersonsDTO>();
        }

        public PersonsDTO Update(PersonsDTO person)
        {
            var entity = person.Adapt<Persons>();
            entity = _repository.Update(entity);
            return entity.Adapt<PersonsDTO>();
        }
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
