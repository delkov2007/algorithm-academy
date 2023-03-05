namespace AlgorithmAcademyAPI.Core.Models.Users
{
    public class UserContact
    {
        public int Id { get; set; }

        public int NameId { get; set; }

        public int UserId { get; set; }
        
        public string Owner { get; set; }

        public string? Email { get; set; }

        public string Phone { get; set; }

        public string? AlternativePhone { get; set; }

        public string? Notes { get; set; }

        public Name Name { get; set; }

    }
}
