using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crisan_Adriana_proiect.Models
{
    public class Category
    {
        public int ID { get; set; }
        [Required, StringLength(80, MinimumLength = 2)]
        public string CategoryName { get; set; }
        public ICollection<ToyCategory> ToyCategories { get; set; }
    }
}
