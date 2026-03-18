using ITIDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITIDB.Context
{
    internal class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=.;Database=ITIUsingEFcore2;Trusted_Connection=True;Encrypt=False;";

            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ins_Course>().HasKey(i => new {i.Crs_Id , i.st_Id});
            modelBuilder.Entity<Std_Course>().HasKey(i => new {i.CourseId , i.StudentId});
           
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Super)
                .WithMany(d => d.StudentsSupervised)
                .HasForeignKey(s=>s.St_super)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Department)
                .WithMany(d => d.Students)
                .HasForeignKey(s=>s.DeptId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
                .HasOne(s => s.Dept_Manager)
                .WithMany(d=>d.DepartmentsManaged)
                .HasForeignKey(s=>s.Dept_ManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Instructor>()
                .HasOne(s => s.Department)
                .WithMany(d=>d.Instructors)
                .HasForeignKey(s=>s.deptId)
                .OnDelete(DeleteBehavior.Restrict);

            
            base.OnModelCreating(modelBuilder);
        }
    }
}
