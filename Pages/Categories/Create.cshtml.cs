using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Crisan_Adriana_proiect.Data;
using Crisan_Adriana_proiect.Models;

namespace Crisan_Adriana_proiect.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly Crisan_Adriana_proiect.Data.Crisan_Adriana_proiectContext _context;

        public CreateModel(Crisan_Adriana_proiect.Data.Crisan_Adriana_proiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Category.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
