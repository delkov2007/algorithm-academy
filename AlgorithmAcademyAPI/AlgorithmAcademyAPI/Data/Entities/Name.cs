namespace AlgorithmAcademyAPI.Data.Entities;

public partial class Name
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public bool Archived { get; set; }

    public DateTime? DateArchived { get; set; }

    public virtual ICollection<UserContact> UserContacts { get; } = new List<UserContact>();

    public virtual ICollection<User> Users { get; } = new List<User>();

}
