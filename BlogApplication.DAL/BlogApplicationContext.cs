using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApplication.DAL
{
   public class BlogApplicationContext: DbContext, IDisposable
    {
        public BlogApplicationContext() : base("name=BlogAppConnection")
        {
            //new DropCreateDatabaseAlways < CodeFirstContext > ()
            Database.SetInitializer<BlogApplicationContext>(null);
            //Database.SetInitializer(new DropCreateDatabaseAlways<BlogApplicationContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Blog> Blog { get; set; }
        public DbSet<Comment> Comment { get; set; }
    }
}
