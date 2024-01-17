namespace ExercisesService.Domain.Models
{
    public class Workout
    {
        public int Id { get; set; }
        public ICollection<WorkoutExercise> Exercises { get; set; } = null!;

        public DateTime WorkoutDate { get; set; } = DateTime.Now;
        public string Description { get; set; } = string.Empty;
    }
}