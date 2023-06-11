using LMMProject.Models;
using Microsoft.EntityFrameworkCore;

namespace LMMProject.Data
{
    //Scaffold-DbContext "server=localhost;user=root;database=flm;password=12345;port=3306" MySql.EntityFrameworkCore -OutputDir flm -Tables thich them table nao thi tu them -f
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Account> Accounts { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.UserName).HasName("PRIMARY");

                entity.ToTable("account");

                entity.HasIndex(e => e.RoleId, "FK_Account_Role");

                entity.Property(e => e.UserName)
                    .HasMaxLength(150)
                    .HasColumnName("userName");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .HasColumnName("address");
                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
                    .HasColumnName("birthday");
                entity.Property(e => e.Fullname)
                    .HasMaxLength(50)
                    .HasColumnName("fullname");
                entity.Property(e => e.Gender).HasColumnName("gender");
                entity.Property(e => e.Gmail)
                    .HasMaxLength(150)
                    .HasColumnName("gmail");
                entity.Property(e => e.Image)
                    .HasMaxLength(50)
                    .HasColumnName("image");
                entity.Property(e => e.Password)
                    .HasMaxLength(150)
                    .HasColumnName("password");
                entity.Property(e => e.Phone).HasColumnName("phone");
                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.HasOne(d => d.Role).WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Account_Role");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleId).HasName("PRIMARY");

                entity.ToTable("role");

                entity.Property(e => e.RoleId).HasColumnName("roleId");
                entity.Property(e => e.RoleName)
                    .HasMaxLength(150)
                    .HasColumnName("roleName");
            });
        }
    }
}
