namespace ExercisesService.Domain.Models
{
    public class ExerciseType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Exercise> Exercises { get; set; } = null!;

    }
}