﻿
using System.Collections.Generic;

namespace CheeseMVC.Models
{
    public class Cheese
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public CheeseCategory Category { get; set; }
   //     [key]
        public int ID { get; set; }
        public int CategoryID { get; set; }
        IList<CheeseMenu> CheeseMenus { get; set; }

    }
}
