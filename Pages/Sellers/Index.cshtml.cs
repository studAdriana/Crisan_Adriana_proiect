﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Crisan_Adriana_proiect.Data;
using Crisan_Adriana_proiect.Models;

namespace Crisan_Adriana_proiect.Pages.Sellers
{
    public class IndexModel : PageModel
    {
        private readonly Crisan_Adriana_proiect.Data.Crisan_Adriana_proiectContext _context;

        public IndexModel(Crisan_Adriana_proiect.Data.Crisan_Adriana_proiectContext context)
        {
            _context = context;
        }

        public IList<Seller> Seller { get;set; }

        public async Task OnGetAsync()
        {
            Seller = await _context.Seller.ToListAsync();
        }
    }
}
