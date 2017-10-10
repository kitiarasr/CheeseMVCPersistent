using CheeseMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.ViewModels
{
    public class ViewMenuViewModel
    {
        public Menu Menu { get; set; }
        public IList<CheeseMenu> Items { get; set; } 
        //to get the items that belong to this menu, we'll
        //need to interact with the CheeseMenu class, which joins Menu
        // to Cheese. Thus, we'll pass in a list of CheeseMenu objects.
    }
}
