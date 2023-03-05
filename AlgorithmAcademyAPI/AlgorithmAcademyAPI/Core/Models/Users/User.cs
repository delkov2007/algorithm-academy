namespace AlgorithmAcademyAPI.Core.Models.Users
{
    public class User
    {
        public int Id { get; set; }

        public int NameId { get; set; }

        public int UserTypeId { get; set; }

        public string Username { get; set; }

        public Name Name { get; set; }

        public UserType UserType { get; set; }

        public List<UserContact> UserContacts { get; set; }

    }
}
