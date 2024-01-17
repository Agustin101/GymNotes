using System.ComponentModel.DataAnnotations;

namespace ExercisesService.Domain.Models
{
    public class WorkoutExercise
    {
        public int Id { get; set; }
        public int TotalSeries { get; set; }
        public ICollection<WorkoutExerciseSerie> SerieDetails { get; set; } = null!;
        public int ExerciseId { get; set; }
        public virtual Exercise Exercise { get; set; } = new();
        public int WorkoutId { get; set; }
        public virtual Workout Workout { get; set; } = new();
    }
}