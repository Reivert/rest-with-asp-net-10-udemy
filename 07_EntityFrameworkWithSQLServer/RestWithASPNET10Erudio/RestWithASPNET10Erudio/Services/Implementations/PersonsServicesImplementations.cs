using Microsoft.EntityFrameworkCore;
using RestWithASPNET10Erudio.Model;
using RestWithASPNET10Erudio.Model.Context;

namespace RestWithASPNET10Erudio.Services.Implementations
{
    public class PersonsServicesImplementations : IPersonsServices
    {
        private MSSQLContext _context;


        public PersonsServicesImplementations(MSSQLContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<Persons> FindAll()
        {
            return _context.Persons.AsNoTracking().ToList();
        }

        public Persons FindById(long id)
        {
            return _context.Persons.Find(id);
        }        

        public Persons Create(Persons persons)
        {
            _context.Persons.Add(persons);
            _context.SaveChanges();
            return persons;
        }

        public Persons Update(Persons persons)
        {
            var existePerson = _context.Persons.Find(persons.Id);

            if (existePerson == null)
                return null;

            _context.Entry(existePerson).CurrentValues.SetValues(persons);
            _context.SaveChanges();

            return existePerson;
        }

        public void Delete(long id)
        {
            var existePerson = _context.Persons.Find(id);

            if (existePerson == null)
                return;

            _context.Remove(existePerson);
            _context.SaveChanges();
        }        
    }
}
