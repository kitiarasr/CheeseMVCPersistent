using CheeseMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CheeseMVC.Data
{
    public class CheeseDbContext : DbContext
    {
        public DbSet<Cheese> Cheeses { get; set; }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<CheeseMenu> CheeseMenus {get; set;}
        //add dbset properties to use with each of the menu and cheesemenu classes.

        public CheeseDbContext(DbContextOptions<CheeseDbContext> options) 
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CheeseMenu>()
                .HasKey(c => new { c.CheeseID, c.MenuID });
        } // this method sets the primary key of the CheeseMenu class and table.. to be composite key,
        //consisting of both c.CheeseId and c.MenuID. These ideas live within CheesMenu class. 

        public DbSet<CheeseCategory> Categories { get; set; }
        //add a new Db Set so that we get instances to be stored in database
        //Since Cheese and CheeseCategory will be related (we'll set this up in
        //Part 2 of this studio), we can put these DbSet properties in the same DbContext.
        //By naming this property Categories, EF will create a table within our database
        //of the same name.
    }
}
