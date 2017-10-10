using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Data;
using Microsoft.EntityFrameworkCore;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class MenuController : Controller
    {
        private CheeseDbContext context;

        public MenuController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        //might actually have to be Index()
        public IActionResult Index()
        {
            //  IList<Cheese> cheeses = context.Cheeses.Include(c => c.Category).ToList();
          //  IList<CheeseMenu> chMenus = context.CheeseMenus.Include(c => c.Menu).ToList();
            IList<Menu> Menus = context.Menus.ToList();
            //retrieve all the menus and display them
            //private context
            ViewBag.Title = "New Menu";
            return View(Menus);
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddMenuViewModel ViewMenu = new AddMenuViewModel();

            return View(ViewMenu);
        }

        [HttpPost]
        public IActionResult Add(AddMenuViewModel ViewMenu)
        {
            if (ModelState.IsValid)
            {

                Menu newMenu = new Menu
                {
                    Name = ViewMenu.Name
                };
                context.Menus.Add(newMenu);
             //   context.CheeseMenus.Add()
                context.SaveChanges();

                return Redirect("/Menu/ViewMenu/" + newMenu.ID);
            }
            return View(ViewMenu); //pass in object so view has somethign to work with

        }
        [HttpGet]
        public IActionResult ViewMenu(int id)
        {
          //  Menu getMenu = context.Menus.Single(id);

          //Retrieve menu object using id
            Menu getMenu = context.Menus.Where(a => a.ID == id).Single();
         
            //get items associated with the menu
            List<CheeseMenu> items = context
                .CheeseMenus
                .Include(item => item.Cheese)
                .Where(cm => cm.MenuID== id)
                .ToList();

            ViewMenuViewModel viewMenuVM = new ViewMenuViewModel();
            viewMenuVM.Menu = getMenu;
            viewMenuVM.Items = items;


            return View(viewMenuVM);
        }
        [HttpGet]
        public IActionResult AddItem(int id)
        {

            IEnumerable<Cheese> cheeses = context.Cheeses.ToList();

            Menu menu = context.Menus.Where(a => a.ID == id).Single();

            AddMenuItemViewModel menuItemVM = new AddMenuItemViewModel(menu, cheeses);
  
            return View(menuItemVM);
        }

        [HttpPost]
        public IActionResult AddItem(AddMenuItemViewModel menuItemVM)
        {
            //use cheese id to find the right cheese to add to THAT menu
            //use menu id to find the right menu
            //perhaps create a new cheese and add it to menu somehow. this is model binding
            //once this is done, direct to viewMenu page.

            //Menu menu = context.Menus.Where(a => a.ID == menuItemVM.menuID).Single();
            //check for copy in db.
            IList<CheeseMenu> existingItems = context.CheeseMenus
            .Where(cm => cm.CheeseID == menuItemVM.cheeseID)
            .Where(cm => cm.MenuID == menuItemVM.menuID).ToList();

            if (existingItems.Count == 0)
            {
                CheeseMenu chMenu = new CheeseMenu
                {
                    MenuID = menuItemVM.menuID,
                    CheeseID = menuItemVM.cheeseID,
                    //    Menu = menu    
                };
                context.CheeseMenus.Add(chMenu);
                context.SaveChanges();
            }
        
           return Redirect("/Menu/ViewMenu/" + menuItemVM.menuID);
        }
    }
}
