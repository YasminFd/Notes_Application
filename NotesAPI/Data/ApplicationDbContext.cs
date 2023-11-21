using Library;
using Microsoft.EntityFrameworkCore;
using NotesAPI.Model;
using System;
using static Azure.Core.HttpHeader;

namespace NotesAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Note> Notes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);//better ad for when adding other migrations
            modelBuilder.Entity<Note>().HasData(new Note
            {
                Id = 1,
                Title = "Shopping",
                Description = "Buy milk, bread and tea"
            });
            modelBuilder.Entity<Note>().HasData(new Note
            {
                Id = 2,
                Title = "School",
                Description = "finish hw"
            });
            //repeat for other values, then add new migration and update db
        }

    }
}
