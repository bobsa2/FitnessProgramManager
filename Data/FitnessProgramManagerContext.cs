using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FitnessProgramManager.Models;

namespace FitnessProgramManager.Data
{
    public class FitnessProgramManagerContext : DbContext
    {
        public FitnessProgramManagerContext (DbContextOptions<FitnessProgramManagerContext> options)
            : base(options)
        {
        }

        public DbSet<FitnessProgramManager.Models.FitnessProgram> FitnessProgram { get; set; } = default!;
    }
}
