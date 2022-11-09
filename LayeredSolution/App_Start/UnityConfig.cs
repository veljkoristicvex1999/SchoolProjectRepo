using System.Web.Mvc;
using DataAccess;
using Unity;
using Unity.Mvc5;
using BusinessLayer;
using BusinessObjectModel;
namespace LayeredSolution
{
	public static class UnityConfig
	{
		public static void RegisterComponents()
		{
			var container = new UnityContainer();

			// register all your components with the container here
			// it is NOT necessary to register your controllers
			//container.RegisterType<IUserRepository, UserRepository>();
			//container.RegisterType<IUserService, UserService>();
			//container.RegisterType<IWidgetRepository, WidgetRepository>();
			container.RegisterType<IFacultyStudentRepository, FacultyStudentRepository>();
		container.RegisterType<IGenericService<FaculltyStudents>, GenericService<FaculltyStudents>>();
			container.RegisterType<IGenericService<HighSchoolStudents>, GenericService<HighSchoolStudents>>();
			container.RegisterType<IFacultyStudentService, FacultyStudentService>();
			container.RegisterType<IHighSchoolRepository, HighSchoolRepository>();
			container.RegisterType<IHighSchoolService, HighSchoolService>();
			
			// e.g. container.RegisterType<ITestService, TestService>();

			DependencyResolver.SetResolver(new UnityDependencyResolver(container));
		}
	}
}