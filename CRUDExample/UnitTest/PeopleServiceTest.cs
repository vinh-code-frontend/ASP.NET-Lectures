using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Enums;
using Services;

namespace UnitTest
{
    public class PeopleServiceTest
    {
        private readonly IPeopleService _peopleService;

        public PeopleServiceTest()
        {
            _peopleService = new PeopleService();
        }

        #region AddPerson
        [Fact]
        public void AddPerson_NullPerson()
        {
            PersonAddRequest? personAddRequest = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                _peopleService.AddPerson(personAddRequest);
            });
        }
        [Fact]
        public void AddPerson_NullPersonName()
        {
            PersonAddRequest? personAddRequest = new PersonAddRequest() { PersonName = null };

            Assert.Throws<ArgumentException>(() =>
            {
                _peopleService.AddPerson(personAddRequest);
            });
        }// => can write for other fields as well
        [Fact]
        public void AddPerson_ProperPersonDetails()
        {
            PersonAddRequest? personAddRequest = new PersonAddRequest()
            {
                PersonName = "Person name...",
                Email = "person@example.com",
                Address = "sample address",
                CountryID = Guid.NewGuid(),
                Gender = GenderOptions.Male,
                DateOfBirth = DateTime.Parse("2000-01-01"),
                ReceiveNewsLetters = true
            };
            PersonResponse personResponseFromAdd = _peopleService.AddPerson(personAddRequest);
            List<PersonResponse> personList = _peopleService.GetAllPersons();

            Assert.True(personResponseFromAdd.PersonID != Guid.Empty);
            Assert.Contains(personResponseFromAdd, personList);

        }
        #endregion
    }

}
