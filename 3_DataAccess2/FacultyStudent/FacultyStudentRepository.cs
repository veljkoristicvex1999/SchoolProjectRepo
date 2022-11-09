using BusinessObjectModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
   
    public class FacultyStudentRepository : GenericRepository<FaculltyStudents>, IFacultyStudentRepository
    {
        static int br = 0;
        
        public FacultyStudentRepository(TuxContext db) : base(db)
        {
           
        }    
        public List<FaculltyStudents> search(string search)
        {
            search = search.ToUpper();
            List<FaculltyStudents> students = table.Where(s => (s.Address).ToUpper().Contains(search) || (s.FacultyName).ToUpper().Contains(search) || (s.BornDate).ToString().ToUpper().Contains(search) || (s.PhoneNumber).ToUpper().Contains(search) || (s.Name).ToUpper().Contains(search) || (s.Email.ToUpper().Contains(search)) || (s.LastName.ToUpper().Contains(search) || (s.Name.ToUpper().Contains(search)))).ToList();
            return students;
        }
      
        public void Export(int id)
        {

            var model = db.FaculltyStudents.Find(id);
            string downloadArea = Path.Combine(@"C:\\Users\\vris\\Desktop");
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(downloadArea, "Student Details.txt" + br)))
            {
                var Name = model.Name;
                var LastName = model.LastName;
                var  PhoneNumber = model.PhoneNumber;
                var Generation = model.Generation;
                var BordnDate = model.BornDate;
                var Address = model.Address;              
                outputFile.WriteLine(Name);
                outputFile.WriteLine(LastName);
                outputFile.WriteLine(PhoneNumber);
                outputFile.WriteLine(Generation);
                outputFile.WriteLine(BordnDate);
                outputFile.WriteLine(Address);
                br++;
            }
        }
    }
}
