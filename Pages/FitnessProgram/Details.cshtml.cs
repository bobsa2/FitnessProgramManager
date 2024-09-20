using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FitnessProgramManager.Data;
using FitnessProgramManager.Models;

namespace FitnessProgramManager.Pages.FitnessProgram
{
    public class DetailsModel : PageModel
    {
        private readonly FitnessProgramManager.Data.FitnessProgramManagerContext _context;

        public DetailsModel(FitnessProgramManager.Data.FitnessProgramManagerContext context)
        {
            _context = context;
        }

        public FitnessProgramManager.Models.FitnessProgram FitnessProgram { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fitnessprogram = await _context.FitnessProgram.FirstOrDefaultAsync(m => m.Id == id);
            if (fitnessprogram == null)
            {
                return NotFound();
            }
            else
            {
                FitnessProgram = fitnessprogram;
            }
            return Page();
        }
    }
}
