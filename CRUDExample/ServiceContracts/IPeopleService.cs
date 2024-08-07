using ServiceContracts.DTO;

namespace ServiceContracts
{
    public interface IPeopleService
    {
        PersonResponse AddPerson(PersonAddRequest? personAddRequest);
        List<PersonResponse> GetAllPersons();
    }
}
