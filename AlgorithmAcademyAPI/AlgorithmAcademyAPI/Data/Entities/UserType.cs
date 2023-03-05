namespace AlgorithmAcademyAPI.Data.Entities;

public partial class UserType
{
    public int Id { get; set; }

    public string TypeName { get; set; } = null!;

    public string NormalizedTypeName { get; set; } = null!;

    public bool Archived { get; set; }

    public DateTime? DateArchived { get; set; }

    public virtual ICollection<User> Users { get; } = new List<User>();
}
