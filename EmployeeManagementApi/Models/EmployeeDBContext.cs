using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EmployeeManagementApi.Models
{
    public partial class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext()
        {
        }

        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeDesignation> EmployeeDesignation { get; set; }
        public virtual DbSet<PaymentRules> PaymentRules { get; set; }
        public virtual DbSet<RequestLeave> RequestLeave { get; set; }
        public virtual DbSet<WorkingHour> WorkingHour { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=MC1JULY201;Initial Catalog=EmployeeDB;User ID=sa;Password=pass@word1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Empid)
                    .HasName("PK__Employee__AF4CE86501422ACC");

                entity.HasIndex(e => e.Mail)
                    .HasName("UQ__Employee__7A212904D89C3348")
                    .IsUnique();

                entity.Property(e => e.Empid)
                    .HasColumnName("empid")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.DesignationName)
                    .HasColumnName("Designation_Name")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Empname)
                    .HasColumnName("empname")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Mail)
                    .HasColumnName("mail")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.HasOne(d => d.DesignationNameNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.DesignationName)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Employee__Design__4BAC3F29");
            });

            modelBuilder.Entity<EmployeeDesignation>(entity =>
            {
                entity.HasKey(e => e.Designation)
                    .HasName("PK__Employee__BE5DF65EB7886D85");

                entity.Property(e => e.Designation)
                    .HasColumnName("designation")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Department)
                    .HasColumnName("department")
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PaymentRules>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Category)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RuleDescription).IsUnicode(false);
            });

            modelBuilder.Entity<RequestLeave>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .HasName("PK__RequestL__CA1EE06C70F057EC");

                entity.Property(e => e.Sno).HasColumnName("SNO");

                entity.Property(e => e.Empid)
                    .HasColumnName("empid")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LeaveReason).IsUnicode(false);

                entity.Property(e => e.NoOfDays).HasColumnName("No_Of_Days");

                entity.Property(e => e.RequestType)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.RequestLeave)
                    .HasForeignKey(d => d.Empid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__RequestLe__empid__619B8048");
            });

            modelBuilder.Entity<WorkingHour>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .HasName("PK__WorkingH__CA1EE06CD617C586");

                entity.Property(e => e.Sno).HasColumnName("SNO");

                entity.Property(e => e.CompanyWorkingHours)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Empid)
                    .HasColumnName("empid")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeWorkingHours)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Employeeshift)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MonthYear)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.WorkingHour)
                    .HasForeignKey(d => d.Empid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__WorkingHo__empid__5DCAEF64");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
