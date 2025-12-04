using Microsoft.EntityFrameworkCore;
using RestWithASPNET10Erudio.Model;
using RestWithASPNET10Erudio.Model.Context;
using RestWithASPNET10Erudio.Repositories;

namespace RestWithASPNET10Erudio.Services.Implementations
{
    public class PersonsServicesImplementations : IPersonsServices
    {
        private IRepository<Persons> _repository;


        public PersonsServicesImplementations(IRepository<Persons> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public List<Persons> FindAll()
        {
            return _repository.FindAll();
        }

        public Persons FindById(long id)
        {
            return _repository.FindById(id);
        }        

        public Persons Create(Persons persons)
        {
            return _repository.Create(persons);
        }

        public Persons Update(Persons persons)
        {
            return _repository.Update(persons);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }        
    }
}
