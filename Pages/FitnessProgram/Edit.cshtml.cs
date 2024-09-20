using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FitnessProgramManager.Data;
using FitnessProgramManager.Models;

namespace FitnessProgramManager.Pages.FitnessProgram
{
    public class EditModel : PageModel
    {
        private readonly FitnessProgramManager.Data.FitnessProgramManagerContext _context;

        public EditModel(FitnessProgramManager.Data.FitnessProgramManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FitnessProgramManager.Models.FitnessProgram FitnessProgram { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fitnessprogram =  await _context.FitnessProgram.FirstOrDefaultAsync(m => m.Id == id);
            if (fitnessprogram == null)
            {
                return NotFound();
            }
            FitnessProgram = fitnessprogram;
            return Page();
        }

       
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(FitnessProgram).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FitnessProgramExists(FitnessProgram.Id))
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

        private bool FitnessProgramExists(int id)
        {
            return _context.FitnessProgram.Any(e => e.Id == id);
        }
    }
}
