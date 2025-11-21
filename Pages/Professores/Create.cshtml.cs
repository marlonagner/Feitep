using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Feitep.Data;
using Feitep.Models;

namespace Feitep.Pages.Professores
{
    public class CreateModel : PageModel
    {
        private readonly Feitep.Data.ApplicationDbContext _context;

        public CreateModel(Feitep.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Professor Professor { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Professores == null || Professor == null)
            {
                return Page();
            }

            _context.Professores.Add(Professor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
