using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Crisan_Adriana_proiect.Data;
using Crisan_Adriana_proiect.Models;

namespace Crisan_Adriana_proiect.Pages.Toys
{
    public class EditModel : ToyCategoriesPageModel
    {
        private readonly Crisan_Adriana_proiect.Data.Crisan_Adriana_proiectContext _context;

        public EditModel(Crisan_Adriana_proiect.Data.Crisan_Adriana_proiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Toy Toy { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Toy = await _context.Toy.Include(b => b.Seller).Include(b => b.ToyCategories).ThenInclude(b => b.Category).AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);

            if (Toy == null)
            {
                return NotFound();
            }
         
            PopulateAssignedCategoryData(_context, Toy);
            ViewData["SellerID"] = new SelectList(_context.Seller, "ID", "SellerName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
            selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var toyToUpdate = await _context.Toy.Include(i => i.Seller).Include(i => i.ToyCategories).ThenInclude(i => i.Category).FirstOrDefaultAsync(s => s.ID == id);

            if (toyToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Toy>(toyToUpdate, "Toy", i => i.Name, i => i.Description, i => i.Price, i => i.Seller))
            {
                UpdateToyCategories(_context, selectedCategories, toyToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateToyCategories(_context, selectedCategories, toyToUpdate);
            PopulateAssignedCategoryData(_context, toyToUpdate);
            return Page();
        }

    }
}

/*
 * if (!ModelState.IsValid)
            {
                return Page();
            }

    _context.Attach(Toy).State = EntityState.Modified;

    try
            {
                await _context.SaveChangesAsync();
            }
    catch (DbUpdateConcurrencyException)
            {
                if (!ToyExists(Toy.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

    return RedirectToPage("./Index");
        }

        private bool ToyExists(int id)
        {
            return _context.Toy.Any(e => e.ID == id);
        }
    }
*/

