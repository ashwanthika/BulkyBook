using Microsoft.EntityFrameworkCore;
using BulkyBookWeb.Models;

namespace BulkyBookWeb.Data
{
    public class AplicationDBContext : DbContext //: DbContext means AplicationDBContext inherits from the DbContext class provided by ef core which is used for interacting with the database.
    {
        public AplicationDBContext(DbContextOptions<AplicationDBContext> options): base (options) //construct which take an It takes a parameter options of type DbContextOptions<AplicationDBContext>. DbContextOptions is a configuration object used by DbContext to set up various database options, such as the database provider (e.g., SQL Server, MySQL) and connection strings.
                                                                                                  //: base(options): This calls the base class (DbContext) constructor with the provided options. This is necessary to properly configure the DbContext.
        {

        }
        public  DbSet<Category> Categories { get; set; } //public DbSet<Category> Categories { get; set; }: This property represents a collection of Category entities that you can query from the database or add to it. Entity Framework will create a table named Categories based on this DbSet.
    }
}


// who calls this dbcontext class ?
//the DbContext is registered with the DI container in the Program.cs

//When you register ApplicationDbContext in Program.cs using builder.Services.AddDbContext<ApplicationDbContext>(...),
//you are telling the DI container that whenever it needs to create an ApplicationDbContext instance, it should configure it using the specified options.