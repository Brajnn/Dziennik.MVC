using Dziennik.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik.Infrastructure.Presistence
{
    public class SchoolDbContext :DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options):base(options)
        {
            
        }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Class> Classes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Marks)
                .WithOne(m => m.Student)
                .HasForeignKey(m => m.StudentId);

            modelBuilder.Entity<Class>()
                 .HasMany(c=>c.Students)
                 .WithOne(s => s.Class)
                 .HasForeignKey(c=>c.ClassId);

            modelBuilder.Entity<Mark>()
                 .HasOne(m => m.Subject)
                 .WithMany(s => s.Marks)
                 .HasForeignKey(m => m.SubjectId);

            modelBuilder.Entity<Teacher>()
                 .HasMany(t => t.Subjects)
                 .WithOne(c => c.Teacher)
                 .HasForeignKey(t=>t.TeacherId);

            modelBuilder.Entity<Teacher>()
                 .HasMany(t => t.Classes)
                 .WithMany(s => s.Teachers);
        }
    }
}
