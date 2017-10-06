using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using System.Collections.Generic;
using CheeseMVC.ViewModels;
using CheeseMVC.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
//using CheeseMVC.Models.CheeseCategory;

//hello 
namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        private CheeseDbContext context;

        public CheeseController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            IList<Cheese> cheeses = context.Cheeses.Include(c => c.Category).ToList(); //EEOR DOESNT RECOGNIZE CATEGORYID

            return View(cheeses);
        }

        public IActionResult Add()
        {
           // if (context.Categories != null)  //just in case categories has nothing inside, I dont want this to possible break
          //  {
                AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel(context.Categories.ToList());
                return View(addCheeseViewModel);
          //  }
        
          //  AddCheeseViewModel addCheeseViewModel2 = new AddCheeseViewModel();
          
         //   return View(addCheeseViewModel2);
        }

        [HttpPost]
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        {
         
            if (ModelState.IsValid)
            {
                CheeseCategory newCheeseCategory =
                  context.Categories.Single(c => c.ID == addCheeseViewModel.CategoryID);

                // Add the new cheese to my existing cheeses
                Cheese newCheese = new Cheese
                {
                    Name = addCheeseViewModel.Name,
                    Description = addCheeseViewModel.Description,
                    Category = newCheeseCategory


            };

                context.Cheeses.Add(newCheese);
                context.SaveChanges();

                return Redirect("/Cheese");
            }

            return View(addCheeseViewModel);
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Cheeses";
            ViewBag.cheeses = context.Cheeses.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] cheeseIds)
        {
            foreach (int cheeseId in cheeseIds)
            {
                Cheese theCheese = context.Cheeses.Single(c => c.ID == cheeseId);
                context.Cheeses.Remove(theCheese);
            }

            context.SaveChanges();

            return Redirect("/");
        }
    }
}
