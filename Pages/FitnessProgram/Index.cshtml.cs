using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FitnessProgramManager.Data;
using FitnessProgramManager.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FitnessProgramManager.Pages.FitnessProgram
{
    public class IndexModel : PageModel
    {
        private readonly FitnessProgramManager.Data.FitnessProgramManagerContext _context;

        public IndexModel(FitnessProgramManager.Data.FitnessProgramManagerContext context)
        {
            _context = context;
        }

        public IList<FitnessProgramManager.Models.FitnessProgram> FitnessProgram { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Names { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? ProgramNames { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SortOrder { get; set; }

        // To store the current sort direction for each column
        public string NameSort { get; set; }
        public string TypeSort { get; set; }
        public string DifficultySort { get; set; }


        public async Task OnGetAsync()
        {
            // Set the sort direction for each column
            NameSort = SortOrder == "Name" ? "name_desc" : "Name";
            TypeSort = SortOrder == "Type" ? "type_desc" : "Type";
            DifficultySort = SortOrder == "Difficulty" ? "difficulty_desc" : "Difficulty";

            var programs = from p in _context.FitnessProgram
                           select p;

            // Apply sorting based on the SortOrder parameter
            switch (SortOrder)
            {
                case "name_desc":
                    programs = programs.OrderByDescending(p => p.Name);
                    break;
                case "Type":
                    programs = programs.OrderBy(p => p.Type);
                    break;
                case "type_desc":
                    programs = programs.OrderByDescending(p => p.Type);
                    break;
                case "Difficulty":
                    programs = programs.OrderBy(p => p.DifficultyLevel);
                    break;
                case "difficulty_desc":
                    programs = programs.OrderByDescending(p => p.DifficultyLevel);
                    break;
                default:
                    programs = programs.OrderBy(p => p.Name); // Default sort by name
                    break;
            }

            // If a search string is provided, filter the results
            if (!string.IsNullOrEmpty(SearchString))
            {
                programs = programs.Where(s => s.Name.Contains(SearchString));
            }

            // This should execute the filtered query and assign it to the FitnessProgram property
            FitnessProgram = await programs.ToListAsync();
        }

        // Handle the rating submission
        public async Task<IActionResult> OnPostRateAsync(int id, int rating)
        {
            // Find the fitness program by ID
            var program = await _context.FitnessProgram.FindAsync(id);
            if (program == null)
            {
                return NotFound();
            }

            // Update the total rating and rating count
            program.TotalRating += rating;
            program.RatingCount += 1;

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Redirect back to the same page to avoid re-posting the form
            return RedirectToPage();
        }
    }
}
