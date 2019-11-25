using StudentDataBase.DB;
using System.Linq;
using System.Web.Mvc;

namespace StudentDataBase.Controllers
{
    public class HomeController : Controller
    {
        CollegeRegistrationEntities db = new CollegeRegistrationEntities();

        public ActionResult Index()
        {
            var StudentDetails = db.Students.ToList();
            return View(StudentDetails);
        }

        [HttpGet]
        public ActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EditStudent(int id)
        {
            var EditRecord = db.Students.FirstOrDefault(s => s.Id == id);
            return View(EditRecord);
        }

        [HttpPost]
        public ActionResult EditStudent(Student student)
        {
            var EditRecord = db.Students.FirstOrDefault(s => s.Id == student.Id);
            EditRecord.Age = student.Age;
            EditRecord.BloodGroup = student.BloodGroup;
            EditRecord.Department = student.Department;
            EditRecord.EmailId = student.EmailId;
            EditRecord.FirstName = student.FirstName;
            EditRecord.Id = student.Id;
            EditRecord.LanguagesKnown = student.LanguagesKnown;
            EditRecord.LastName = student.LastName;
            EditRecord.MobileNumber = student.MobileNumber;
            EditRecord.RollNumber = student.RollNumber;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteStudent(int id)
        {
            var DeleteRecord = db.Students.FirstOrDefault(s => s.Id == id);
            return View(DeleteRecord);
        }

        [HttpPost]
        public ActionResult DeleteStudent(Student student)
        {
            var DeleteRecord = db.Students.FirstOrDefault(s => s.Id == student.Id);
            db.Students.Remove(DeleteRecord);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult StudentDetails(int id)
        {
            var ViewRecord = db.Students.FirstOrDefault(s => s.Id == id);
            return View(ViewRecord);
        }
    }
}