using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Feitep.Data;
using Feitep.Models;

namespace Feitep.Pages.Equipamentos
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
        ViewData["ProfessorId"] = new SelectList(_context.Professores, "Id", "Email");
            return Page();
        }

        [BindProperty]
        public Equipamento Equipamento { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Equipamentos == null || Equipamento == null)
            {
                return Page();
            }

            _context.Equipamentos.Add(Equipamento);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
