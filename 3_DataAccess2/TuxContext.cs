using BusinessObjectModel;
using System.Data.Entity;
using System.Diagnostics.Contracts;

namespace DataAccess
{
	public class TuxContext : DbContext
	{
        public TuxContext() : base("Student")
        {

        }
		public DbSet<Student> Students { get; set; }
		public DbSet<HighSchoolStudents> HighSchoolStudents { get; set; }
		public DbSet<FaculltyStudents> FaculltyStudents { get; set; }



		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			

			Database.SetInitializer<TuxContext>(null);
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<HighSchoolStudents>()
				.Map<HighSchoolStudents>(m => m.Requires("BillingDetailType").HasValue("HighSchool"));


			modelBuilder.Entity<FaculltyStudents>()
			.Map<FaculltyStudents>(m => m.Requires("BillingDetailType").HasValue("Facullty"));


			modelBuilder.Entity<Student>().ToTable("Student");

	//		modelBuilder.Entity<HighSchoolStudents>().Property(p=>"HighSchool").HasColumnName("Type").IsOptional();
		//	modelBuilder.Entity<FaculltyStudents>().Property(p=> "Facullty").HasColumnName("Type").IsOptional();
			modelBuilder.Entity<Student>().ToTable("Student");
			modelBuilder.Entity<Student>().HasKey<int>(s => s.Id);
			modelBuilder.Entity<Student>().Property(p => p.Name).HasColumnName("Name").IsRequired();
			modelBuilder.Entity<Student>().Property(p => p.LastName).HasColumnName("LastName").IsRequired();
			modelBuilder.Entity<Student>().Property(p => p.BornDate).HasColumnName("BornDate").IsRequired();
			modelBuilder.Entity<Student>().Property(p => p.Email).HasColumnName("Email").IsOptional();
			modelBuilder.Entity<Student>().Property(p => p.Address).HasColumnName("Address").IsOptional();
			modelBuilder.Entity<Student>().Property(p => p.PhoneNumber).HasColumnName("PhoneNumber").IsOptional();
			

			modelBuilder.Entity<FaculltyStudents>().Property(p => p.FacultyName).HasColumnName("FacultyName").IsOptional();
			modelBuilder.Entity<FaculltyStudents>().Property(p => p.Generation).HasColumnName("Generation").IsOptional();
			modelBuilder.Entity<HighSchoolStudents>().Property(p => p.SchoolName).HasColumnName("SchoolName").IsOptional();
			modelBuilder.Entity<HighSchoolStudents>().Property(p => p.DateOfEnrollment).HasColumnName("DateOfEnrollment").IsOptional();
		}
	}
}
