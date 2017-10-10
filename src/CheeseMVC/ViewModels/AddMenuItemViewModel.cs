using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.ViewModels
{
    public class AddMenuItemViewModel
    {
        //used to render and process the form to add
        //a new item to given menu
        public int cheeseID { get; set; }
        public int menuID { get; set; }
        public Menu Menu { get; set; }
        public List<SelectListItem> Cheeses { get; set; }


        public AddMenuItemViewModel()
        {
   
        }

        public AddMenuItemViewModel(Menu menu, IEnumerable<Cheese> ch) 
        {
            Menu = menu;
            Cheeses = new List<SelectListItem>();
            //Cheeses = cheeses;
            //Add all the cheese brought into function to selectlistitem
            foreach (var cheese in ch) {
                Cheeses.Add(new SelectListItem
                {
                    Value = cheese.ID.ToString(),
                    Text = cheese.Name
    
            });
            }

        }
    }
}
