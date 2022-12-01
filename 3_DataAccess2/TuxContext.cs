using BusinessObjectModel;
using System.Data.Entity;
namespace DataAccess

{
    public class TuxContext : DbContext
	{
        public TuxContext() : base("MVCStudents")
        {

        }
		public DbSet<User> Users { get; set; }
		public DbSet<UserRoles> UserRoles { get; set; }
		public DbSet<HighSchoolStudents> HighSchoolStudents { get; set; }
		public DbSet<FaculltyStudents> FaculltyStudents { get; set; }
		public DbSet<Roles> Roles { get; set; }



		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{


			Database.SetInitializer<TuxContext>(null);
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<HighSchoolStudents>().Map<HighSchoolStudents>(m => m.Requires("BillingDetailType").HasValue("HighSchool"));
			modelBuilder.Entity<FaculltyStudents>().Map<FaculltyStudents>(m => m.Requires("BillingDetailType").HasValue("Facullty"));
			modelBuilder.Entity<Admin>().Map<Admin>(m => m.Requires("BillingDetailType").HasValue("Admin"));
			modelBuilder.Entity<Professor>().Map<Professor>(m => m.Requires("BillingDetailType").HasValue("Professor"));




			modelBuilder.Entity<Roles>().ToTable("t_roles");
			modelBuilder.Entity<Roles>().HasKey<int>(s => s.RoleId);
			modelBuilder.Entity<Roles>().Property(p => p.RoleName).HasColumnName("RoleName").IsRequired();
			modelBuilder.Entity<Roles>().HasMany(p => p.UserRoles).WithRequired().HasForeignKey(p => p.RoleId);
			

			modelBuilder.Entity<User>().ToTable("t_users");
			modelBuilder.Entity<User>().HasKey<int>(s => s.Id);
	

			modelBuilder.Entity<User>().HasMany(p => p.Roles).WithRequired().HasForeignKey(p=>p.Id);
			modelBuilder.Entity<User>().Property(p => p.Name).HasColumnName("Name").IsRequired();
			modelBuilder.Entity<User>().Property(p => p.LastName).HasColumnName("LastName").IsRequired();
			modelBuilder.Entity<User>().Property(p => p.BornDate).HasColumnName("BornDate").IsRequired();
			modelBuilder.Entity<User>().Property(p => p.Email).HasColumnName("Email").IsOptional();
			modelBuilder.Entity<User>().Property(p => p.Address).HasColumnName("Address").IsOptional();
			modelBuilder.Entity<User>().Property(p => p.PhoneNumber).HasColumnName("PhoneNumber").IsOptional();
			modelBuilder.Entity<User>().Property(p => p.Password).HasColumnName("Password").IsRequired();

			modelBuilder.Entity<FaculltyStudents>().Property(p => p.FacultyName).HasColumnName("FacultyName").IsOptional();
			modelBuilder.Entity<FaculltyStudents>().Property(p => p.Generation).HasColumnName("Generation").IsOptional();
			modelBuilder.Entity<HighSchoolStudents>().Property(p => p.SchoolName).HasColumnName("SchoolName").IsOptional();
			modelBuilder.Entity<HighSchoolStudents>().Property(p => p.DateOfEnrollment).HasColumnName("DateOfEnrollment").IsOptional();

			modelBuilder.Entity<Professor>().Property(p => p.HoursPerWeek).HasColumnName("HoursPerWeek").IsOptional();
			modelBuilder.Entity<Professor>().Property(p => p.Subject).HasColumnName("Subject").IsOptional();

			modelBuilder.Entity<UserRoles>().HasKey(ur =>new { ur.Id, ur.RoleId});
			modelBuilder.Entity<UserRoles>().Property(p => p.RoleId).HasColumnName("RoleId").IsRequired();
			modelBuilder.Entity<UserRoles>().Property(p => p.Id).HasColumnName("Id").IsRequired();
			modelBuilder.Entity<UserRoles>().ToTable("t_user_roles");
		

		}

    //    public System.Data.Entity.DbSet<LayeredSolution.ViewModels.FaculltyViewModel> FaculltyViewModels { get; set; }

     //   public System.Data.Entity.DbSet<LayeredSolution.ViewModels.HighSchoolViewModel> HighSchoolViewModels { get; set; }

     //   public System.Data.Entity.DbSet<LayeredSolution.ViewModels.ProfessorViewModel> ProfessorViewModels { get; set; }

        // public System.Data.Entity.DbSet<LayeredSolution.ViewModels.AdminViewModel> AdminViewModels { get; set; }
    }
}
