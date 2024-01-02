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
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SchoolDb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Marks)
                .WithOne(m => m.Student)
                .HasForeignKey(m => m.StudentId);

            modelBuilder.Entity<Subject>()
                .HasMany(sub => sub.Marks)
                .WithOne(mark => mark.Subject)
                .HasForeignKey(mark => mark.SubjectId);
        }
    }
}
