using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crisan_Adriana_proiect.Models
{
    public class ToyCategory
    {
        public int ID { get; set; }
        public int ToyID { get; set; }
        public Toy Toy { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }

    }
}
