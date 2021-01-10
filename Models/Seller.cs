using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crisan_Adriana_proiect.Models
{
    public class Seller
    {
        public int ID { get; set; }
        [StringLength(30)]
        public string SellerName { get; set; }
        public ICollection<Toy> Toys { get; set; }
    }
}
