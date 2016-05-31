using Meowdit.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Meowdit.DAL
{
    public class MeowContext : DbContext
    {
        public MeowContext() : base("MeowContext") {}

        public DbSet<Meow> Meows { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}