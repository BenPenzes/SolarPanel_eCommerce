using SolarPanelBackend.Models;

namespace SolarPanelBackend.Data.Repositories
{
    public interface IPersonRepository
    {
        public int InsertPersonAndLoginInformation(PersonModel personModel);
        public KeyValuePair<string, int> CheckLoginInformation(LoginInformationModel loginInformation);
    }
}
