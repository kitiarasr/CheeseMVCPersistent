using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models
{
    public class CheeseCategory
    {
        internal int ID { get; set; }   //I made this internal in order for ID and name to be printed out of the view. Any other way?
        internal string Name { get; set; }

    }
}
