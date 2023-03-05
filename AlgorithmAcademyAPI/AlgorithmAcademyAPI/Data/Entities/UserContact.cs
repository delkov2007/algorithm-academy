namespace AlgorithmAcademyAPI.Data.Entities;

public partial class UserContact
{
    public int Id { get; set; }

    public int NameId { get; set; }

    public int UserId { get; set; }

    public string Owner { get; set; } = null!;

    public string? Email { get; set; }

    public string Phone { get; set; } = null!;

    public string? AlternativePhone { get; set; }

    public string? Notes { get; set; }

    public bool Archived { get; set; }

    public DateTime? DateArchived { get; set; }

    public virtual Name Name { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
