using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Crisan_Adriana_proiect.Data;
using Crisan_Adriana_proiect.Models;

namespace Crisan_Adriana_proiect.Pages.Toys
{
    public class DetailsModel : PageModel
    {
        private readonly Crisan_Adriana_proiect.Data.Crisan_Adriana_proiectContext _context;

        public DetailsModel(Crisan_Adriana_proiect.Data.Crisan_Adriana_proiectContext context)
        {
            _context = context;
        }

        public Toy Toy { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Toy = await _context.Toy.FirstOrDefaultAsync(m => m.ID == id);

            if (Toy == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
