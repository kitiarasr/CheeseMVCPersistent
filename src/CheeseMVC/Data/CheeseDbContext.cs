using CheeseMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CheeseMVC.Data
{
    public class CheeseDbContext : DbContext
    {
        public DbSet<Cheese> Cheeses { get; set; }

        public CheeseDbContext(DbContextOptions<CheeseDbContext> options) 
            : base(options)
        { }

        public DbSet<CheeseCategory> Categories { get; set; }
        //add a new Db Set so that we get instances to be stored in database
        //Since Cheese and CheeseCategory will be related (we'll set this up in
        //Part 2 of this studio), we can put these DbSet properties in the same DbContext.
        //By naming this property Categories, EF will create a table within our database
        //of the same name.
    }
}
