using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DAL
{
    public class Dbcontext: DbContext
    { 
        public Dbcontext() : base("DBConnectionString")
        {
           
        }

        public DbSet<Domains.User> Users { get; set; }
        public DbSet<Domains.BookReadingEvent> BookReadingEvents { get; set; }
       // public DbSet<Domains.InvitedToEvent> InvitedToEvents { get; set; }
        public DbSet<Domains.PostedComment> PostedComments { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }      
    }
}
