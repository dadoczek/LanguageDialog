using Microsoft.AspNet.Identity.EntityFramework;
using Model.Migrations;
using Model.Models;
using System.Data.Entity;

namespace Model.Context
{
    public class EfContext : IdentityDbContext<User>
    {
        public EfContext()
            : base("Aplikacja_Lingwistyczna_1", false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EfContext, Configuration>());
        }

        public EfContext(string name)
            : base(name, false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EfContext, Configuration>());
        }

        public DbSet<Dialogue> Dialogue { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<Actor> Actor { get; set; }
        public DbSet<Issue> Issue { get; set; }
        public DbSet<AudioFile> AudioFile { get; set; }
        public DbSet<UserDialogue> UserDialogue { get; set; }
        public DbSet<UserLanguage> UserLanguage { get; set; }
        public DbSet<ViewLanguage> ViewLanguage { get; set; }
        public DbSet<ViewText> ViewText { get; set; }

        public static EfContext Create()
        {
            return new EfContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Issue>()
                .HasOptional(s => s.Dialogue)
                .WithMany()
                .WillCascadeOnDelete(false);
        }
    }
}
