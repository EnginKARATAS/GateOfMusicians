using LoginYap4.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginYap4.DataAccessLayer
{
    public class DatabaseContext : DbContext
    {
           
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Song>()
           .MapToStoredProcedures(config =>
           {
               config.Insert(i => i.HasName("SP_SongInserted"));
               config.Update(u =>
               {
                   u.HasName("SP_SongUpdated");
                   u.Parameter(p => p.Id, "SongId");
               });
               config.Delete(d => d.HasName("SP_SongDeleted"));
           });

            modelBuilder.Entity<Log>().ToTable("Logs");
            modelBuilder.Entity<SiteUser>().ToTable("SiteUser");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Liked>().ToTable("Liked");
            modelBuilder.Entity<Chord>().ToTable("Chord");
            modelBuilder.Entity<Comment>().ToTable("Comment");
            modelBuilder.Entity<Song>().ToTable("Song");
        }


        public DbSet<Log> Logs { get; set; }
        public DbSet<SiteUser> SiteUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Liked> Likes { get; set; }
        public DbSet<Chord> Chords { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DatabaseContext()
        {
            Database.SetInitializer(new MyInitilizer());
        }
    }
}
