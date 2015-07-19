using System.Data.Entity;

namespace Shorty.Data
{
    public class Context : DbContext
    {
        public Context(): base("name=Shorty")
        {
            //Database.SetInitializer<Context>(new DropCreateDatabaseAlways<Context>());
        }
        
        public DbSet<UserUrl> Urls { get; set; }
    }
}