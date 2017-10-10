
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CheeseMVC.Models
{
    public class Cheese
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public CheeseCategory Category { get; set; }

        public int ID { get; set; }

        public int CategoryID { get; set; }

        IList<CheeseMenu> CheeseMenus { get; set; }

    }
}
