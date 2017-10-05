using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CategoryController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
         //   List<Models.CheeseCategory> one = context.Categories.ToList();

            //returns a list of all CheeseCategory objects managed by CheeseDbContext.
            //retrieves list of categories, then pass the list into the view.
            return View(context.Categories.ToList());
        }

        private readonly CheeseDbContext context;

        public CategoryController(CheeseDbContext dbContext)
        {
            context = dbContext;

        }

        /*This creates a private field context of type CheeseDbContext. This object will be the mechanism with which we interact with objects stored in the database. The MVC framework will do the work of creating an instance of CheeseDbContext and passing it into our controller's constructor.

This code would need to be added to each controller class that you want to have access to the persistent collections defined within CheeseDbContext.
   */ }
}
