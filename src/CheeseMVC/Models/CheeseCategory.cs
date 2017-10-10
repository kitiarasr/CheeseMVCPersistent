using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models
{
    public class CheeseCategory
    {
        public int ID { get; set; }   //I made this internal in order for ID and name to be printed out of the view. Any other way?
        public string Name { get; set; }
        IList<Cheese> Cheeses { get; set; }
    }
}
