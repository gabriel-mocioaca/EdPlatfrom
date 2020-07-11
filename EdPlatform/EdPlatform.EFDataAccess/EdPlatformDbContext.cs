using EdPlatform.ApplicationLogic.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdPlatform.EFDataAccess
{
  public class EdPlatformDbContext : DbContext
  {
    public EdPlatformDbContext() { }

    public EdPlatformDbContext(DbContextOptions<EdPlatformDbContext> options)
      : base(options)
    {
    }

    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<Assignment> Assignments { get; set; }
    public DbSet<Classroom> Classrooms { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<ClassroomMessage> ClassroomMessages { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<UserAssignment> UserAssignments { get; set; }
    public DbSet<UserClassroom> UserClassrooms { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<ApplicationUser>().HasKey(t => t.UserId);
      modelBuilder.Entity<Assignment>().HasKey(t => t.AssignmentId);
      modelBuilder.Entity<Classroom>().HasKey(t => t.ClassroomId);
      modelBuilder.Entity<Message>().HasKey(t => t.MessageId);

      modelBuilder.Entity<ClassroomMessage>().HasKey(x => new { x.ClassroomId, x.MessageId });
      modelBuilder.Entity<ClassroomMessage>().HasOne(cl => cl.Classroom).WithMany(me => me.ClassroomMessages).HasForeignKey(cl => cl.ClassroomId);
      modelBuilder.Entity<ClassroomMessage>().HasOne(me => me.Message).WithMany(cl => cl.ClassroomMessages).HasForeignKey(me => me.MessageId);

      modelBuilder.Entity<UserAssignment>().HasKey(x => new { x.UserId, x.AssignmentId });
      modelBuilder.Entity<UserAssignment>().HasOne(us => us.ApplicationUser).WithMany(ass => ass.UserAssignments).HasForeignKey(cl => cl.UserId);
      modelBuilder.Entity<UserAssignment>().HasOne(ass => ass.Assignment).WithMany(us => us.UserAssignments).HasForeignKey(ass => ass.UserId);

      modelBuilder.Entity<UserClassroom>().HasKey(x => new { x.UserId, x.ClassroomId });
      modelBuilder.Entity<UserClassroom>().HasOne(us => us.ApplicationUser).WithMany(cl => cl.UserClassrooms).HasForeignKey(us => us.UserId);
      modelBuilder.Entity<UserClassroom>().HasOne(cl => cl.Classroom).WithMany(me => me.UserClassrooms).HasForeignKey(cl => cl.ClassroomId);

      modelBuilder.Entity<ClassroomStudents>().HasKey(x => new { x.StudentId, x.ClassroomId });
      modelBuilder.Entity<ClassroomStudents>().HasOne(su => su.Student).WithMany(cl => cl.ClassroomStudents).HasForeignKey(us => us.StudentId);
      modelBuilder.Entity<ClassroomStudents>().HasOne(cl => cl.Classroom).WithMany(me => me.ClassroomStudents).HasForeignKey(cl => cl.ClassroomId);

      base.OnModelCreating(modelBuilder);
    }
  }
}
