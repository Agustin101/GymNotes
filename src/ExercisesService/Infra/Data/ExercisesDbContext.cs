
using ExercisesService.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ExercisesService.Infra.Data
{
    public class ExercisesDbContext : DbContext
    {
        public ExercisesDbContext(DbContextOptions<ExercisesDbContext> opts) : base(opts)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Workout>()
                .HasMany(w => w.Exercises)
                .WithOne(we => we.Workout)
                .HasPrincipalKey(w => w.Id)
                .HasForeignKey(w => w.WorkoutId);

            modelBuilder.Entity<WorkoutExercise>()
                .HasOne(we => we.Workout)
                .WithMany(w => w.Exercises)
                .HasPrincipalKey(e => e.Id)
                .HasForeignKey(w => w.WorkoutId);

            modelBuilder.Entity<WorkoutExercise>()
            .HasMany(w => w.SerieDetails)
            .WithOne(we => we.Workout)
            .HasPrincipalKey(w => w.Id)
            .HasForeignKey(w => w.WorkoutExerciseId);

            modelBuilder.Entity<WorkoutExerciseSerie>()
            .HasOne(wes => wes.Workout)
            .WithMany(we => we.SerieDetails)
            .HasPrincipalKey(w => w.Id)
            .HasForeignKey(w => w.WorkoutExerciseId);

            modelBuilder.Entity<WorkoutExercise>()
            .HasOne(w => w.Exercise)
            .WithMany(e => e.WorkoutExercises)
            .HasPrincipalKey(w => w.Id)
            .HasForeignKey(w => w.ExerciseId);

            modelBuilder.Entity<Exercise>()
            .HasMany(w => w.WorkoutExercises)
            .WithOne(e => e.Exercise)
            .HasPrincipalKey(w => w.Id)
            .HasForeignKey(w => w.ExerciseId);

            modelBuilder.Entity<WorkoutExerciseSerie>()
            .HasOne(wes => wes.Unit)
            .WithMany(we => we.WorkoutExerciseSerie)
            .HasPrincipalKey(w => w.Id)
            .HasForeignKey(w => w.UnitId);

            modelBuilder.Entity<ExerciseUnit>()
            .HasMany(e => e.WorkoutExerciseSerie)
            .WithOne(we => we.Unit)
            .HasPrincipalKey(w => w.Id)
            .HasForeignKey(w => w.UnitId);

            modelBuilder.Entity<Exercise>()
.HasOne(e => e.Category)
.WithMany(we => we.Exercises)
.HasPrincipalKey(w => w.Id)
.HasForeignKey(w => w.CategoryId);

            modelBuilder.Entity<ExerciseCategory>()
.HasMany(e => e.Exercises)
.WithOne(we => we.Category)
.HasPrincipalKey(w => w.Id)
.HasForeignKey(w => w.CategoryId);

            modelBuilder.Entity<Exercise>()
.HasOne(e => e.Type)
.WithMany(we => we.Exercises)
.HasPrincipalKey(w => w.Id)
.HasForeignKey(w => w.ExerciseTypeId);

            modelBuilder.Entity<ExerciseType>()
.HasMany(e => e.Exercises)
.WithOne(we => we.Type)
.HasPrincipalKey(w => w.Id)
.HasForeignKey(w => w.ExerciseTypeId);

            modelBuilder.Entity<Exercise>()
.HasOne(e => e.Unit)
.WithMany(we => we.Exercises)
.HasPrincipalKey(w => w.Id)
.HasForeignKey(w => w.ExerciseUnitId);

            modelBuilder.Entity<ExerciseUnit>()
.HasMany(e => e.Exercises)
.WithOne(we => we.Unit)
.HasPrincipalKey(w => w.Id)
.HasForeignKey(w => w.ExerciseUnitId);
        }

        public DbSet<WorkoutExerciseSerie> WorkoutExerciseSerie { get; set; }
        public DbSet<WorkoutExercise> WorkoutExercise { get; set; }
        public DbSet<Workout> Workout { get; set; }
        public DbSet<ExerciseUnit> ExerciseUnit { get; set; }
        public DbSet<ExerciseType> ExerciseType { get; set; }
        public DbSet<ExerciseCategory> ExerciseCategory { get; set; }
        public DbSet<Exercise> Exercise { get; set; }
    }
}