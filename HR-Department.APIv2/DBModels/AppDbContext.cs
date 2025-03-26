using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HR_Department.APIv2.DBModels;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Authorization> Authorizations { get; set; }

    public virtual DbSet<Child> Children { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<DepartmentOrganization> DepartmentOrganizations { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<Person> Persons { get; set; }

    public virtual DbSet<PersonAuthorization> PersonAuthorizations { get; set; }

    public virtual DbSet<PersonChild> PersonChild { get; set; }

    public virtual DbSet<PersonDepartment> PersonDepartments { get; set; }

    public virtual DbSet<PersonPosition> PersonPositions { get; set; }

    public virtual DbSet<PersonSalary> PersonSalaries { get; set; }

    public virtual DbSet<PersonVacation> PersonVacations { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Salary> Salaries { get; set; }

    public virtual DbSet<Vacation> Vacations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=test2;Username=postgres;Password=postgres");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pgcrypto");

        modelBuilder.Entity<Authorization>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Authorization_pkey");

            entity.ToTable("Authorization");

            entity.HasIndex(e => e.Login, "authorization_login_unique").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnName("ID");
            entity.Property(e => e.Login).HasMaxLength(255);
            entity.Property(e => e.Role).HasMaxLength(255);
            entity.Property(e => e.UpdateAt).HasColumnName("UpdateAT");
        });

        modelBuilder.Entity<Child>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Child_pkey");

            entity.ToTable("Child");

            entity.Property(e => e.Id)
                .HasColumnName("ID");
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.MidleName).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(255);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Department_pkey");

            entity.ToTable("Department");

            entity.Property(e => e.Id)
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<DepartmentOrganization>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("DepartmentOrganization_pkey");

            entity.ToTable("DepartmentOrganization");

            entity.Property(e => e.Id)
                .HasColumnName("ID");
            entity.Property(e => e.DepartmentId).HasColumnName("Department_ID");
            entity.Property(e => e.OrganizationId).HasColumnName("Organization_ID");

            entity.HasOne(d => d.Department).WithMany(p => p.DepartmentOrganizations)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("departmentorganization_department_id_foreign");

            entity.HasOne(d => d.Organization).WithMany(p => p.DepartmentOrganizations)
                .HasForeignKey(d => d.OrganizationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("departmentorganization_organization_id_foreign");
        });

        modelBuilder.Entity<Organization>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Organization_pkey");

            entity.ToTable("Organization");

            entity.Property(e => e.Id)
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id)
            .HasName("Person_pkey");
            

            entity.ToTable("Person");

            entity.HasIndex(e => e.Email, "person_email_unique").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnName("ID");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.MidleName).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(255);
        });

        modelBuilder.Entity<PersonAuthorization>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PersonAuthorization_pkey");

            entity.ToTable("PersonAuthorization");

            entity.Property(e => e.Id)
                .HasColumnName("ID");
            entity.Property(e => e.AuthorizationId).HasColumnName("Authorization_ID");
            entity.Property(e => e.PersonId).HasColumnName("Person_ID");

            entity.HasOne(d => d.Authorization).WithMany(p => p.PersonAuthorizations)
                .HasForeignKey(d => d.AuthorizationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("personauthorization_autorization_id_foreign");

            entity.HasOne(d => d.Person).WithMany(p => p.PersonAuthorizations)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("personauthorization_person_id_foreign");
        });

        modelBuilder.Entity<PersonChild>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PersonChild_pkey");

            entity.ToTable("PersonChild");

            entity.Property(e => e.Id)
                .HasColumnName("ID");
            entity.Property(e => e.ChildId).HasColumnName("Child_ID");
            entity.Property(e => e.PersonId).HasColumnName("Person_ID");

        });

        modelBuilder.Entity<PersonDepartment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PersonDepartment_pkey");

            entity.ToTable("PersonDepartment");

            entity.Property(e => e.Id)
                .HasColumnName("ID");
            entity.Property(e => e.DepartmentId).HasColumnName("Department_ID");
            entity.Property(e => e.PersonId).HasColumnName("Person_ID");

            entity.HasOne(d => d.Department).WithMany(p => p.PersonDepartments)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("persondepartment_department_id_foreign");

            entity.HasOne(d => d.Person).WithMany(p => p.PersonDepartments)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("persondepartment_person_id_foreign");
        });

        modelBuilder.Entity<PersonPosition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PersonPosition_pkey");

            entity.ToTable("PersonPosition");

            entity.Property(e => e.Id)
                .HasColumnName("ID");
            entity.Property(e => e.PersonId).HasColumnName("Person_ID");
            entity.Property(e => e.PositionId).HasColumnName("Position_ID");

            entity.HasOne(d => d.Person).WithMany(p => p.PersonPositions)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("person/position_person_id_foreign");

            entity.HasOne(d => d.Position).WithMany(p => p.PersonPositions)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("person/position_position_id_foreign");
        });

        modelBuilder.Entity<PersonSalary>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PersonSalary_pkey");

            entity.ToTable("PersonSalary");

            entity.Property(e => e.Id)
                .HasColumnName("ID");
            entity.Property(e => e.PersonId).HasColumnName("Person_ID");
            entity.Property(e => e.SalaryId).HasColumnName("Salary_ID");

            entity.HasOne(d => d.Person).WithMany(p => p.PersonSalaries)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("personsalary_person_id_foreign");

            entity.HasOne(d => d.Salary).WithMany(p => p.PersonSalaries)
                .HasForeignKey(d => d.SalaryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("personsalary_salary_id_foreign");
        });

        modelBuilder.Entity<PersonVacation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PersonVacation_pkey");

            entity.ToTable("PersonVacation");

            entity.Property(e => e.Id)
                .HasColumnName("ID");
            entity.Property(e => e.PersonId).HasColumnName("Person_ID");
            entity.Property(e => e.VacationId).HasColumnName("Vacation_ID");

            entity.HasOne(d => d.Person).WithMany(p => p.PersonVacations)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("personvacation_person_id_foreign");

            entity.HasOne(d => d.Vacation).WithMany(p => p.PersonVacations)
                .HasForeignKey(d => d.VacationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("personvacation_vacation_id_foreign");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Position_pkey");

            entity.ToTable("Position");

            entity.Property(e => e.Id)
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Salary>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Salary_pkey");

            entity.ToTable("Salary");

            entity.Property(e => e.Id)
                .HasColumnName("ID");
            entity.Property(e => e.Amount).HasPrecision(8, 2);
        });

        modelBuilder.Entity<Vacation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Vacation_pkey");

            entity.ToTable("Vacation");

            entity.Property(e => e.Id)
                .HasColumnName("ID");
            entity.Property(e => e.VacationType).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
