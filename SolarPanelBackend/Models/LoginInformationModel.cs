namespace SolarPanelBackend.Models
{
    public class LoginInformationModel
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public LoginInformationModel(string Email, string PasswordHash) {
            this.Email = Email;
            this.PasswordHash = PasswordHash;
        }  
    }
}
