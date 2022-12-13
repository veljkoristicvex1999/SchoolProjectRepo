
using BusinessObjectModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{

    public class HighSchoolRepository : GenericRepository<HighSchoolStudents>, IHighSchoolRepository
    {
        static int br = 0;


        public HighSchoolRepository(TuxContext db)
            : base(db)
        {

        }

       

        public void Export(int id)
        {
            var model = db.HighSchoolStudents.Find(id);
            string downloadArea = Path.Combine(@"C:\\Users\\vris\\Desktop");
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(downloadArea, "HighSchoolStudents Details.txt" + br)))
            {
                var Name = model.Name;
                var LastName = model.LastName;
                var PhoneNumber = model.PhoneNumber;
                var Date = model.DateOfEnrollment;
                var BordnDate = model.BornDate;
                var Address = model.Address;
                var school = model.SchoolName;
                outputFile.WriteLine(Name);
                outputFile.WriteLine(LastName);
                outputFile.WriteLine(PhoneNumber);
                outputFile.WriteLine(Date);
                outputFile.WriteLine(BordnDate);
                outputFile.WriteLine(Address);
                outputFile.WriteLine(school);
                br++;
            }
        }    

        public override void Create(HighSchoolStudents Student)
        {
                table.Add(Student);
                db.UserRoles.AddRange(Student.Roles);
                db.SaveChanges();
        }

        public override void Delete(object id)
        {
            var model = table.Include("Roles").Where(a => a.Id == (int)id).First();
            if (model != null)
            {
                table.Attach(model);
                db.UserRoles.RemoveRange(model.Roles);
                table.Remove(model);
                db.SaveChanges();
            }
        }

        public HighSchoolStudents findByEmail(string email)
        {
            return table.Where(a => a.Email == email).First();
        }

        public List<HighSchoolStudents> Search(string search)
        {
            search = search.ToUpper();
            List<HighSchoolStudents> students = table.Where(s => (s.Address).ToUpper().Contains(search) || (s.SchoolName).ToUpper().Contains(search) || (s.BornDate).ToString().ToUpper().Contains(search) || (s.PhoneNumber).ToUpper().Contains(search) || (s.Name).ToUpper().Contains(search) || (s.Email.ToUpper().Contains(search)) || (s.LastName.ToUpper().Contains(search) || (s.Name.ToUpper().Contains(search)))).ToList();
            return students;
        }

        public List<HighSchoolStudents> GetAllStudents()
        {
            return table.ToList();
        }
    }
}
