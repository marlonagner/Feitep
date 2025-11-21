using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Feitep.Data;
using Feitep.Models;

namespace Feitep.Pages.Equipamentos
{
    public class IndexModel : PageModel
    {
        private readonly Feitep.Data.ApplicationDbContext _context;

        public IndexModel(Feitep.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Equipamento> Equipamento { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Equipamentos != null)
            {
                Equipamento = await _context.Equipamentos
                .Include(e => e.Professor).ToListAsync();
            }
        }
    }
}
