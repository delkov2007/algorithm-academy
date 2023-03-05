using Microsoft.EntityFrameworkCore;

namespace AlgorithmAcademyAPI.Data
{
    using AlgorithmAcademyAPI.Data.Entities;

    public partial class AlgorithmAcademyContext : DbContext
    {
        public AlgorithmAcademyContext()
        {
        }

        public AlgorithmAcademyContext(DbContextOptions<AlgorithmAcademyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Name> Names { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<UserContact> UserContacts { get; set; }

        public virtual DbSet<UserType> UserTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Name>(entity =>
            {
                entity.Property(e => e.DateArchived).HasColumnType("datetime");
                entity.Property(e => e.FirstName).HasMaxLength(50);
                entity.Property(e => e.LastName).HasMaxLength(50);
                entity.Property(e => e.MiddleName).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.DateArchived).HasColumnType("datetime");
                entity.Property(e => e.Password).HasMaxLength(50);
                entity.Property(e => e.Username).HasMaxLength(50);

                entity.HasOne(d => d.Name).WithMany(p => p.Users)
                    .HasForeignKey(d => d.NameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Names");

                entity.HasOne(d => d.UserType).WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_UserTypes");
            });

            modelBuilder.Entity<UserContact>(entity =>
            {
                entity.Property(e => e.AlternativePhone).HasMaxLength(50);
                entity.Property(e => e.DateArchived).HasColumnType("datetime");
                entity.Property(e => e.Email).HasMaxLength(500);
                entity.Property(e => e.Notes).HasMaxLength(400);
                entity.Property(e => e.Owner).HasMaxLength(50);
                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.HasOne(d => d.Name).WithMany(p => p.UserContacts)
                    .HasForeignKey(d => d.NameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserContacts_Names");

                entity.HasOne(d => d.User).WithMany(p => p.UserContacts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserContacts_Users");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.Property(e => e.DateArchived).HasColumnType("datetime");
                entity.Property(e => e.NormalizedTypeName).HasMaxLength(50);
                entity.Property(e => e.TypeName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}