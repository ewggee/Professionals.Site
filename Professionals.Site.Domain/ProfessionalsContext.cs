using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Professionals.Site.Domain.Entitites;

namespace Professionals.Site.Domain;

public partial class ProfessionalsContext : DbContext
{
    public ProfessionalsContext()
    {
    }

    public ProfessionalsContext(DbContextOptions<ProfessionalsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<NewsEvent> NewsEvents { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data source=ПОДСТРИЖЕНЕЦ\\SQLEXPRESS;Initial catalog=Professionals;Integrated security=True;Trust server certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__employee__C52E0BA830E39C18");

            entity.ToTable("employees");

            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.BitrhDate).HasColumnName("bitrh_date");
            entity.Property(e => e.CorporativeEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("corporative_email");
            entity.Property(e => e.EndWorkDate).HasColumnName("end_work_date");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.ManagerId).HasColumnName("manager_id");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("middle_name");
            entity.Property(e => e.OfficeId).HasColumnName("office_id");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.PersonalPhone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("personal_phone");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.QualificationLevelId).HasColumnName("qualification_level_id");
            entity.Property(e => e.StartWorkDate).HasColumnName("start_work_date");
            entity.Property(e => e.WorkPhone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("work_phone");

            entity.HasOne(d => d.Manager).WithMany(p => p.InverseManager)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("FK_employees_employees");

            entity.HasOne(d => d.Post).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_employees_posts");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.ToTable("news");

            entity.Property(e => e.NewsId)
                .ValueGeneratedNever()
                .HasColumnName("news_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Picture).HasColumnName("picture");
            entity.Property(e => e.PicturePath)
                .HasColumnType("text")
                .HasColumnName("picture_path");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("title");
        });

        modelBuilder.Entity<NewsEvent>(entity =>
        {
            entity.ToTable("news_events");

            entity.Property(e => e.NewsEventId)
                .ValueGeneratedNever()
                .HasColumnName("news_event_id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Text)
                .HasColumnType("text")
                .HasColumnName("text");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("title");

            entity.HasOne(d => d.Author).WithMany(p => p.NewsEvents)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_news_events_employees");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.ToTable("posts");

            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.PostName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("post_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
