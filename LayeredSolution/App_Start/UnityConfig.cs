using System.Web.Mvc;
using DataAccess;
using Unity;
using Unity.Mvc5;
using BusinessLayer;
using BusinessObjectModel;
using Unity.Injection;

namespace LayeredSolution
{
	public static class UnityConfig
	{
		public static void RegisterComponents()
		{
			var container = new UnityContainer();

			// register all your components with the container here
			// it is NOT necessary to register your controllers
		

			container.RegisterType<IGenericRepository<HighSchoolStudents>, GenericRepository<HighSchoolStudents>>();
			container.RegisterType<IGenericRepository<FaculltyStudents>, GenericRepository<FaculltyStudents>>();

			container.RegisterType<IFacultyStudentRepository, FacultyStudentRepository>();
		    container.RegisterType<IGenericService<FaculltyStudents>, GenericService<FaculltyStudents>>();
			 container.RegisterType<IGenericService<HighSchoolStudents>, GenericService<HighSchoolStudents>>();
			container.RegisterType<IGenericService<User>, GenericService<User>>();
			container.RegisterType<IGenericRepository<User>, GenericRepository<User>>();
			container.RegisterType<IUserRepository, UserRepository>();
			container.RegisterType<IUserService, UserService>();


			container.RegisterType<IFacultyStudentService, FacultyStudentService>();
			container.RegisterType<IHighSchoolRepository, HighSchoolRepository>();
			container.RegisterType<IHighSchoolService, HighSchoolService>();
			container.RegisterType<IAdminRepository, AdminRepository>();
            container.RegisterType<IAdminService, AdminService>();
			container.RegisterType<IProfessorRepository, ProfessorRepository>();
			container.RegisterType<IProfessorService, ProfessorService>();
			container.RegisterType<IRolesRepository, RolesRepository>();
			container.RegisterType<IRolesService, RolesService>();
			// e.g. container.RegisterType<ITestService, TestService>();

			DependencyResolver.SetResolver(new UnityDependencyResolver(container));
		}
	}
}