namespace ExercisesService.Domain.Models
{
    public class WorkoutExerciseSerie
    {
        public int Id { get; set; }
        public int Position { get; set; }
        public int Repetitions { get; set; }
        public int UnitId { get; set; }
        public virtual ExerciseUnit Unit { get; set; } = null!;
        public int WorkoutExerciseId { get; set; }
        public virtual WorkoutExercise Workout { get; set; } = null!;
    }
}