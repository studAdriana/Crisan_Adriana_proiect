using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crisan_Adriana_proiect.Models
{
    public class Toy
    {
        public int ID { get; set; }

        [Required, StringLength(200, MinimumLength = 2)]
        [Display(Name = "Toy Name")]
        public string Name { get; set; }

        [Required, StringLength(800, MinimumLength = 5)]
        public string Description { get; set; }
        [Range(1, 300)]

        [Column(TypeName = "decimal(15,2)")]
        public decimal Price { get; set; }
        public int SellerID { get; set; }
        public Seller Seller { get; set; }

        public ICollection<ToyCategory> ToyCategories { get; set; }
    }
}
