using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessProgramManager.Models
{
    public class FitnessProgram
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Name { get; set; }

        [Required]
        [StringLength(30)]
        public string? Type { get; set; }  // Cardio, Strength, etc.

        [Required]
        [Range(1, 52)]
        [Display(Name = "Duration in weeks")]
        public int DurationInWeeks { get; set; }

        [Required]
        [Display(Name = "Difficulty level")]
        public string? DifficultyLevel { get; set; }

        // New fields for the rating system
        public int TotalRating { get; set; } 
        public int RatingCount { get; set; } 

        
        public double AverageRating
        {
            get
            {
                return RatingCount == 0 ? 0 : (double)TotalRating / RatingCount;
            }
        }
    }

 }
