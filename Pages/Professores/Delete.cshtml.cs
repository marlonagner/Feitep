using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Feitep.Data;
using Feitep.Models;

namespace Feitep.Pages.Professores
{
    public class DeleteModel : PageModel
    {
        private readonly Feitep.Data.ApplicationDbContext _context;

        public DeleteModel(Feitep.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Professor Professor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Professores == null)
            {
                return NotFound();
            }

            var professor = await _context.Professores.FirstOrDefaultAsync(m => m.Id == id);

            if (professor == null)
            {
                return NotFound();
            }
            else 
            {
                Professor = professor;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Professores == null)
            {
                return NotFound();
            }
            var professor = await _context.Professores.FindAsync(id);

            if (professor != null)
            {
                Professor = professor;
                _context.Professores.Remove(Professor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
