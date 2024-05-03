namespace WebHousingAssociation.Models.ViewModels
{
    public class BoardRoleViewModel
    {
        public List<BoardRole> BoardRoles { get; set; }

    }

    public class BoardRole
    {
        public string RoleName { get; set; }
        public List<string> Residents { get; set; }
        public DateTime LastModified { get; set; }
    }
}
