using Microsoft.AspNet.Identity.EntityFramework;
using Model.Models;
using System.Data.Entity;

namespace Model.Context
{
    public class EfContext : IdentityDbContext<User>
    {
        public EfContext()
            : base("Aplikacja_Lingwistyczna_1", throwIfV1Schema: false)
        {
        }

        public DbSet<Dialogue> Dialogue { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<Actor> Actor { get; set; }
        public DbSet<Issue> Issue { get; set; }
        public DbSet<AudioFile> AudioFile { get; set; }
        public DbSet<UserDialogue> UserDialogue { get; set; }

        public static EfContext Create()
        {
            return new EfContext();
        }
    }
}
