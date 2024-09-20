using Microsoft.EntityFrameworkCore;
using FitnessProgramManager.Data;

namespace FitnessProgramManager.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new FitnessProgramManagerContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<FitnessProgramManagerContext>>()))
            {
                // Check if the context or the FitnessProgram DbSet is null
                if (context == null || context.FitnessProgram == null)
                {
                    throw new ArgumentNullException("Null FitnessProgramContext");
                }

                // Look for any fitness programs in the database.
                if (context.FitnessProgram.Any())
                {
                    return;   // Database has already been seeded
                }

                // Seed initial fitness programs
                context.FitnessProgram.AddRange(
                    new FitnessProgram
                    {
                        Name = "Beginner Strength Training",
                        Type = "Strength",
                        DurationInWeeks = 6,
                        DifficultyLevel = "Beginner"
                    },
                    new FitnessProgram
                    {
                        Name = "Advanced HIIT Workout",
                        Type = "Cardio",
                        DurationInWeeks = 8,
                        DifficultyLevel = "Advanced"
                    },
                    new FitnessProgram
                    {
                        Name = "Yoga for Flexibility",
                        Type = "Yoga",
                        DurationInWeeks = 4,
                        DifficultyLevel = "Intermediate"
                    },
                    new FitnessProgram
                    {
                        Name = "Marathon Training",
                        Type = "Cardio",
                        DurationInWeeks = 12,
                        DifficultyLevel = "Advanced"
                    }
                );

                // Save the changes to the database
                context.SaveChanges();
            }
        }
    }
}
