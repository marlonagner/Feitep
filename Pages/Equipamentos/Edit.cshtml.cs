using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Feitep.Data;
using Feitep.Models;

namespace Feitep.Pages.Equipamentos
{
    public class EditModel : PageModel
    {
        private readonly Feitep.Data.ApplicationDbContext _context;

        public EditModel(Feitep.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Equipamento Equipamento { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Equipamentos == null)
            {
                return NotFound();
            }

            var equipamento =  await _context.Equipamentos.FirstOrDefaultAsync(m => m.Id == id);
            if (equipamento == null)
            {
                return NotFound();
            }
            Equipamento = equipamento;
           ViewData["ProfessorId"] = new SelectList(_context.Professores, "Id", "Email");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Equipamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipamentoExists(Equipamento.Id))
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

        private bool EquipamentoExists(int id)
        {
          return (_context.Equipamentos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
