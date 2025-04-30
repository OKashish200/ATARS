using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TeacherAttendance.Models;

public partial class TeacherAttendanceContext : DbContext
{
    public TeacherAttendanceContext()
    {
    }

    public TeacherAttendanceContext(DbContextOptions<TeacherAttendanceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adminuser> Adminusers { get; set; }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Leaf> Leaves { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<PlayingWithNeon> PlayingWithNeons { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<Timetable> Timetables { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//............. => optionsBuilder.UseNpgsql("Host=ep-white-water-a4rdemfo-pooler.us-east-1.aws.neon.tech;Database=TeacherAttendance;Username=TeacherAttendance_owner;Password=npg_zE5oZTmAb1OM");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Adminuser>(entity =>
        {
            entity.HasKey(e => e.Adminid).HasName("adminusers_pkey");

            entity.ToTable("adminusers");

            entity.Property(e => e.Adminid)
                .HasMaxLength(10)
                .HasColumnName("adminid");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .HasColumnName("role");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.Recordid).HasName("attendance_pkey");

            entity.ToTable("attendance");

            entity.Property(e => e.Recordid)
                .HasMaxLength(10)
                .HasColumnName("recordid");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .HasColumnName("status");
            entity.Property(e => e.Subjectid)
                .HasMaxLength(10)
                .HasColumnName("subjectid");
            entity.Property(e => e.Teacherid)
                .HasMaxLength(10)
                .HasColumnName("teacherid");

            entity.HasOne(d => d.Subject).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.Subjectid)
                .HasConstraintName("attendance_subjectid_fkey");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.Teacherid)
                .HasConstraintName("attendance_teacherid_fkey");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Classid).HasName("classes_pkey");

            entity.ToTable("classes");

            entity.Property(e => e.Classid)
                .HasMaxLength(10)
                .HasColumnName("classid");
            entity.Property(e => e.Classname)
                .HasMaxLength(100)
                .HasColumnName("classname");
            entity.Property(e => e.Section)
                .HasMaxLength(10)
                .HasColumnName("section");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Departmentid).HasName("departments_pkey");

            entity.ToTable("departments");

            entity.Property(e => e.Departmentid)
                .HasMaxLength(10)
                .HasColumnName("departmentid");
            entity.Property(e => e.Departmentname)
                .HasMaxLength(100)
                .HasColumnName("departmentname");
        });

        modelBuilder.Entity<Leaf>(entity =>
        {
            entity.HasKey(e => e.Leaveid).HasName("leaves_pkey");

            entity.ToTable("leaves");

            entity.Property(e => e.Leaveid)
                .HasMaxLength(10)
                .HasColumnName("leaveid");
            entity.Property(e => e.Enddate).HasColumnName("enddate");
            entity.Property(e => e.Reason)
                .HasMaxLength(200)
                .HasColumnName("reason");
            entity.Property(e => e.Startdate).HasColumnName("startdate");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.Teacherid)
                .HasMaxLength(10)
                .HasColumnName("teacherid");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Leaves)
                .HasForeignKey(d => d.Teacherid)
                .HasConstraintName("leaves_teacherid_fkey");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Notificationid).HasName("notifications_pkey");

            entity.ToTable("notifications");

            entity.Property(e => e.Notificationid)
                .HasMaxLength(10)
                .HasColumnName("notificationid");
            entity.Property(e => e.Datesent).HasColumnName("datesent");
            entity.Property(e => e.Message)
                .HasMaxLength(255)
                .HasColumnName("message");
            entity.Property(e => e.Recipientid)
                .HasMaxLength(10)
                .HasColumnName("recipientid");

            entity.HasOne(d => d.Recipient).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.Recipientid)
                .HasConstraintName("notifications_recipientid_fkey");
        });

        modelBuilder.Entity<PlayingWithNeon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("playing_with_neon_pkey");

            entity.ToTable("playing_with_neon");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Studentid).HasName("students_pkey");

            entity.ToTable("students");

            entity.Property(e => e.Studentid)
                .HasMaxLength(10)
                .HasColumnName("studentid");
            entity.Property(e => e.Classid)
                .HasMaxLength(10)
                .HasColumnName("classid");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .HasColumnName("gender");
            entity.Property(e => e.Studentname)
                .HasMaxLength(100)
                .HasColumnName("studentname");

            entity.HasOne(d => d.Class).WithMany(p => p.Students)
                .HasForeignKey(d => d.Classid)
                .HasConstraintName("students_classid_fkey");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Subjectid).HasName("subjects_pkey");

            entity.ToTable("subjects");

            entity.Property(e => e.Subjectid)
                .HasMaxLength(10)
                .HasColumnName("subjectid");
            entity.Property(e => e.Subjectname)
                .HasMaxLength(100)
                .HasColumnName("subjectname");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Teacherid).HasName("teachers_pkey");

            entity.ToTable("teachers");

            entity.Property(e => e.Teacherid)
                .HasMaxLength(10)
                .HasColumnName("teacherid");
            entity.Property(e => e.Departmentid)
                .HasMaxLength(10)
                .HasColumnName("departmentid");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .HasColumnName("gender");
            entity.Property(e => e.Subjectid)
                .HasMaxLength(10)
                .HasColumnName("subjectid");
            entity.Property(e => e.Teachername)
                .HasMaxLength(100)
                .HasColumnName("teachername");

            entity.HasOne(d => d.Department).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.Departmentid)
                .HasConstraintName("teachers_departmentid_fkey");

            entity.HasOne(d => d.Subject).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.Subjectid)
                .HasConstraintName("teachers_subjectid_fkey");
        });

        modelBuilder.Entity<Timetable>(entity =>
        {
            entity.HasKey(e => e.Timetableid).HasName("timetable_pkey");

            entity.ToTable("timetable");

            entity.Property(e => e.Timetableid)
                .HasMaxLength(10)
                .HasColumnName("timetableid");
            entity.Property(e => e.Classid)
                .HasMaxLength(10)
                .HasColumnName("classid");
            entity.Property(e => e.Day)
                .HasMaxLength(10)
                .HasColumnName("day");
            entity.Property(e => e.Period)
                .HasMaxLength(10)
                .HasColumnName("period");
            entity.Property(e => e.Subjectid)
                .HasMaxLength(10)
                .HasColumnName("subjectid");
            entity.Property(e => e.Teacherid)
                .HasMaxLength(10)
                .HasColumnName("teacherid");

            entity.HasOne(d => d.Class).WithMany(p => p.Timetables)
                .HasForeignKey(d => d.Classid)
                .HasConstraintName("timetable_classid_fkey");

            entity.HasOne(d => d.Subject).WithMany(p => p.Timetables)
                .HasForeignKey(d => d.Subjectid)
                .HasConstraintName("timetable_subjectid_fkey");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Timetables)
                .HasForeignKey(d => d.Teacherid)
                .HasConstraintName("timetable_teacherid_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
