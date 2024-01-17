namespace ExercisesService.Domain.Models
{
    public class ExerciseUnit
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<WorkoutExerciseSerie> WorkoutExerciseSerie { get; set; } = null!;
        public ICollection<Exercise> Exercises { get; set; } = null!;

    }
}