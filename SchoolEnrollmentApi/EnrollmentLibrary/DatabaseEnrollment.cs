using Microsoft.EntityFrameworkCore;
using SchoolEnrollmentApi.EnrollmentLibrary.Models;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace SchoolEnrollmentApi.EnrollmentLibrary
{
    public class DatabaseEnrollment  : DbContext
    {
        public DatabaseEnrollment(DbContextOptions<DatabaseEnrollment> options) : base(options)
        {
        }
        public DbSet<Course> Course { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<ExamRecord> ExamRecord { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Requirement> Requirement { get; set; }
        public DbSet<Scholarship> Scholarship { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<AvailabilityStatus> AvailabilityStatus { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<TStatus> TaskStatus { get; set; }
        public DbSet<StudentType> StudentType { get; set; }
        public DbSet<StudyLoad> StudyLoad { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<StudyLoadSubject> StudyLoadSubject { get; set; }
        public DbSet<SubjectsAmount> SubjectsAmount { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder); //connection string
        //}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                .HasIndex(Student => Student.Email)
                .IsUnique();

            modelBuilder.Entity<Student>()
                .HasIndex(Student => Student.PhoneNumber)
                .IsUnique();

            modelBuilder.Entity<Instructor>()
                .HasIndex(Instructor => Instructor.Email)
                .IsUnique();

            modelBuilder.Entity<Instructor>()
                .HasIndex(Instructor => Instructor.PhoneNumber)
                .IsUnique();

            modelBuilder.Entity<Enrollment>()
                .Property(Enrollment => Enrollment.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Enrollment>()
                .Property(Enrollment => Enrollment.UpdatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Payment>()
                .Property(Payment => Payment.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Payment>()
                .Property(Payment => Payment.UpdatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Subject>()
                .Property(Subject => Subject.Units)
                .HasDefaultValue(0);

            modelBuilder.Entity<StudyLoad>()
                .Property(StudyLoad => StudyLoad.TotalUnits)
                .HasDefaultValue(0);

            modelBuilder.Entity<Subject>()
                .Property(Subject => Subject.SubjectPayment)
                .HasDefaultValue(0.0);

            modelBuilder.Entity<SubjectsAmount>()
                .Property(SubjectsAmount => SubjectsAmount.SubjectsTotalAmount)
                .HasDefaultValue(0.0);

            modelBuilder.Entity<Payment>()
                .Property(Payment => Payment.PaymentTuition)
                .HasDefaultValue(0.0);

            modelBuilder.Entity<Payment>()
                .Property(Payment => Payment.EntranceFee)
                .HasDefaultValue(0.0);

            modelBuilder.Entity<Scholarship>()
                .Property(Scholarship => Scholarship.Amount)
                .HasDefaultValue(0.0);

            modelBuilder.Entity<Enrollment>()
                .Property(Enrollment => Enrollment.TotalAmount)
                .HasDefaultValue(0.0);

            modelBuilder.Entity<Instructor>()
                .Property(Instructor => Instructor.ExternalPosition)
                .HasDefaultValue("Professor");

            // One to Many

            //        modelBuilder.Entity<Order>()
            //.HasOne(o => o.Customer)
            //.WithMany(c => c.Orders)
            //.HasForeignKey(o => o.CustomerId);


            //Many to Many

    //        modelBuilder.Entity<StudentCourse>()
    //.HasKey(sc => new { sc.StudentId, sc.CourseId });

        }


    }
}
