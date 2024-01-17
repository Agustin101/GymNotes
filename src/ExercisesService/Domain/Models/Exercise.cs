namespace ExercisesService.Domain.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public virtual ExerciseCategory Category { get; set; } = new();
        public int ExerciseTypeId { get; set; }
        public virtual ExerciseType Type { get; set; } = new();
        public int ExerciseUnitId { get; set; }
        public virtual ExerciseUnit Unit { get; set; } = new();
        public ICollection<WorkoutExercise> WorkoutExercises { get; set; } = null!;
    }
}