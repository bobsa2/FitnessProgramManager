using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FitnessProgramManager.Data;
using FitnessProgramManager.Models;

namespace FitnessProgramManager.Pages.FitnessProgram
{
    public class CreateModel : PageModel
    {
        private readonly FitnessProgramManager.Data.FitnessProgramManagerContext _context;

        public CreateModel(FitnessProgramManager.Data.FitnessProgramManagerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FitnessProgramManager.Models.FitnessProgram FitnessProgram { get; set; } = default!;

        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.FitnessProgram.Add(FitnessProgram);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
