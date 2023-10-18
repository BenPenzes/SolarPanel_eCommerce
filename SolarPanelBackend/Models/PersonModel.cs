namespace SolarPanelBackend.Models
{
    public class PersonModel
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Job { get; set; }
        public LoginInformationModel LoginInformation { get; set; }
        public List<ProjectModel>? Projects { get; set; }
        public PersonModel(int PersonID, string FirstName, string LastName, string Job, LoginInformationModel LoginInformation, List<ProjectModel>? Projects)
        {
            this.PersonID = PersonID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Job = Job;
            this.LoginInformation = LoginInformation;
            this.Projects = Projects;
        }
    }
}
