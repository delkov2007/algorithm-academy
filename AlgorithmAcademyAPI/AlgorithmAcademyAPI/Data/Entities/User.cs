namespace AlgorithmAcademyAPI.Data.Entities;

public partial class User
{
    public int Id { get; set; }

    public int NameId { get; set; }

    public int UserTypeId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool Active { get; set; }

    public bool Archived { get; set; }

    public DateTime? DateArchived { get; set; }

    public virtual Name Name { get; set; } = null!;

    public virtual ICollection<UserContact> UserContacts { get; } = new List<UserContact>();

    public virtual UserType UserType { get; set; } = null!;
}
