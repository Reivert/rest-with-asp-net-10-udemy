using RestWithASPNET10Erudio.Model;

namespace RestWithASPNET10Erudio.Services.Implementations
{
    public class PersonsServicesImplementations : IPersonsServices
    {
        public Persons FindById(int id)
        {
            var person = mockPerson((int) id);
            return person;
        }        

        public List<Persons> FindAll()
        {
            List<Persons> persons = new List<Persons>();
            for (int i = 0; i < 8; i++)
            {
                persons.Add(mockPerson(i));
            }

            return persons;
        }

        public Persons Create(Persons persons)
        {
            persons.Id = new Random().Next(1, 1000);
            return persons;
        }
        public Persons Update(Persons persons)
        {
            return persons;
        }

        public void Delete(long id)
        {
            //Simule
        }
        
        private Persons mockPerson(int i)
        {
            var person = new Persons
            {
                Id = new Random().Next(1, 1000),
                FirstName = "John" + i,
                LastName = "Doe" + i,
                Address = "123 Main St, Anytown, USA" + i,
                Gender = "Male"
            };

            return person;
        }
    }
}
