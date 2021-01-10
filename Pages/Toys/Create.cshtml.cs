using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Crisan_Adriana_proiect.Data;
using Crisan_Adriana_proiect.Models;

namespace Crisan_Adriana_proiect.Pages.Toys
{
    public class CreateModel : ToyCategoriesPageModel
    {
        private readonly Crisan_Adriana_proiect.Data.Crisan_Adriana_proiectContext _context;

        public CreateModel(Crisan_Adriana_proiect.Data.Crisan_Adriana_proiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["SellerID"] = new SelectList(_context.Seller, "ID", "SellerName");
            var toy = new Toy();
            toy.ToyCategories = new List<ToyCategory>();
            PopulateAssignedCategoryData(_context, toy);

            return Page();
        }

        [BindProperty]
        public Toy Toy { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newToy = new Toy();
            if (selectedCategories != null)
            {
                newToy.ToyCategories = new List<ToyCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new ToyCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newToy.ToyCategories.Add(catToAdd);
                }

            }
            if (await TryUpdateModelAsync<Toy>(newToy,"Toy",i => i.Name, i => i.Description,i => i.Price, i => i.SellerID))
            {
                _context.Toy.Add(newToy);
               await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateAssignedCategoryData(_context, newToy);
            return Page();
        }
    }
}
/*
  if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Toy.Add(Toy);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
*/
