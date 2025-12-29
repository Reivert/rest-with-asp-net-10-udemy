using FluentAssertions;
using RestWithASPNET10Erudio.Data.Converter.Implementation;
using RestWithASPNET10Erudio.Data.DTO.V1;
using RestWithASPNET10Erudio.Data.DTO.V2;
using RestWithASPNET10Erudio.Model;
using PersonsDTO = RestWithASPNET10Erudio.Data.DTO.V2.PersonsDTO;

namespace RestWithASPNET10Erudio.Tests
{
    public class PersonConverterTests
    {
        private readonly PersonConverter _converter;

        public PersonConverterTests()
        {
            _converter = new PersonConverter();
        }

        [Fact]
        public void Parse_ShouldConverterPersonDTOToPerson()
        {
            // Arrange: prepare test data, objects, and any necessary setup
            var personDTO = new PersonsDTO
            {
                Id = 1,
                FirstName = "Mahatma",
                LastName = "Gandhi",
                Address = "Porbandar, Índia",
                Gender = "Male",
                BirthDay = new DateTime(1869, 10, 2)
            };

            var expectedPerson = new Persons
            {
                Id = 1,
                FirstName = "Mahatma",
                LastName = "Gandhi",
                Address = "Porbandar, Índia",
                Gender = "Male"
            };

            // Act: call the method under test
            var personResult = _converter.Parse(personDTO);

            // Assert: verify the results
            personResult.Should().NotBeNull();
            personResult.Id.Should().Be(expectedPerson.Id);
            personResult.FirstName.Should().Be(expectedPerson.FirstName);
            personResult.LastName.Should().Be(expectedPerson.LastName);
            personResult.Gender.Should().Be(expectedPerson.Gender);
            personResult.Address.Should().Be(expectedPerson.Address);

            personResult.Should().BeEquivalentTo(expectedPerson);

        }

        [Fact]
        public void Parse_NullPersonDTOShouldreturnNull()
        {
            PersonsDTO dto = null;
            var result = _converter.Parse(dto);
            result.Should().BeNull();
        }

        [Fact]
        public void Parse_ShouldConverterPersonToPersonDTO()
        {
            // Arrange: prepare test data, objects, and any necessary setup
            var entity = new Persons
            {
                Id = 1,
                FirstName = "Mahatma",
                LastName = "Gandhi",
                Address = "Porbandar, Índia",
                Gender = "Male"
            };

            var expectedPerson = new PersonsDTO
            {
                Id = 1,
                FirstName = "Mahatma",
                LastName = "Gandhi",
                Address = "Porbandar, Índia",
                Gender = "Male"
            };

            // Act: call the method under test
            var personResult = _converter.Parse(entity);

            // Assert: verify the results
            personResult.Should().NotBeNull();
            personResult.Id.Should().Be(expectedPerson.Id);
            personResult.FirstName.Should().Be(expectedPerson.FirstName);
            personResult.LastName.Should().Be(expectedPerson.LastName);
            personResult.Gender.Should().Be(expectedPerson.Gender);
            personResult.Address.Should().Be(expectedPerson.Address);

            personResult.Should().BeEquivalentTo(expectedPerson,
                options => options.Excluding(personResult => personResult.BirthDay));

            personResult.BirthDay.Should().NotBeNull();

        }

        [Fact]
        public void Parse_NullPersonShouldReturnNull()
        {
            Persons entity = null;
            var result = _converter.Parse(entity);
            result.Should().BeNull();
        }

        [Fact]
        public void ParseList_ShouldConvertPersonDTOListToPersonList()
        {
            // Arrange
            var dtoList = new List<PersonsDTO>
            {
                new PersonsDTO
                {
                    Id = 1,
                    FirstName = "Mahatma",
                    LastName = "Gandhi",
                    Address = "Porbandar - India",
                    Gender = "Male",
                    BirthDay = new DateTime(1869, 10, 2)
                },
                new PersonsDTO
                {
                    Id = 2,
                    FirstName = "Indira",
                    LastName = "Gandhi",
                    Address = "Allahabad - India",
                    Gender = "Female",
                    BirthDay = new DateTime(1917, 11, 19)
                }
            };

            // Act
            var personList = _converter.ParseList(dtoList);

            // Assert
            personList.Should().NotBeNull();
            personList.Should().HaveCount(2);

            personList[0].Should().BeEquivalentTo(new Persons
            {
                Id = 1,
                FirstName = "Mahatma",
                LastName = "Gandhi",
                Address = "Porbandar - India",
                Gender = "Male",
                //BirthDay = new DateTime(1869, 10, 2)
            });
            personList[1].Should().BeEquivalentTo(new Persons
            {
                Id = 2,
                FirstName = "Indira",
                LastName = "Gandhi",
                Address = "Allahabad - India",
                Gender = "Female"
            });

            personList[0].FirstName.Should().Be("Mahatma");
            personList[1].FirstName.Should().Be("Indira");
            personList[1].LastName.Should().Be("Gandhi");
        }

        [Fact]
        public void Parse_NullListPersonDTOShouldReturnNull()
        {
            List<PersonsDTO> dto = null;
            var listPerson = _converter.ParseList(dto);
            listPerson.Should().BeNull();
        }

        [Fact]
        public void ParseList_ShouldConvertPersonListToPersonDTOList()
        {
            // Arrange
            var dtoList = new List<Persons>
            {
                new Persons
                {
                    Id = 1,
                    FirstName = "Mahatma",
                    LastName = "Gandhi",
                    Address = "Porbandar - India",
                    Gender = "Male",
                    //BirthDay = new DateTime(1869, 10, 2)
                },
                new Persons
                {
                    Id = 2,
                    FirstName = "Indira",
                    LastName = "Gandhi",
                    Address = "Allahabad - India",
                    Gender = "Female",
                    //BirthDay = new DateTime(1917, 11, 19)
                }
            };

            // Act
            var personList = _converter.ParseList(dtoList);

            // Assert
            personList.Should().NotBeNull();
            personList.Should().HaveCount(2);

            personList[0].Should().BeEquivalentTo(new PersonsDTO
            {
                Id = 1,
                FirstName = "Mahatma",
                LastName = "Gandhi",
                Address = "Porbandar - India",
                Gender = "Male",
                BirthDay = new DateTime(1869, 10, 2)
            }, options => options.Excluding(person => person.BirthDay));

            personList[1].Should().BeEquivalentTo(new PersonsDTO
            {
                Id = 2,
                FirstName = "Indira",
                LastName = "Gandhi",
                Address = "Allahabad - India",
                Gender = "Female",
                BirthDay = new DateTime(1917, 11, 19)
            }, options => options.Excluding(person => person.BirthDay));

            personList[0].FirstName.Should().Be("Mahatma");
            personList[1].FirstName.Should().Be("Indira");
            personList[1].LastName.Should().Be("Gandhi");
        }

        [Fact]
        public void Parse_NullListPersonShouldReturnNull()
        {
            List<Persons> dto = null;
            var listPerson = _converter.ParseList(dto);
            listPerson.Should().BeNull();
        }
    }
}
