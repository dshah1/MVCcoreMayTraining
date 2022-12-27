using Microsoft.AspNetCore.Mvc;
using PatientAppDec.PatientModel;
using ProjectDbContext;

namespace PatientAppDec.Controllers
{
    public class PatientController : Controller
    {
        private PatientDbContext _db = null;
        public PatientController(PatientDbContext db)
        {
            _db = db;
            _db.Database.EnsureCreated();
        }
        public IActionResult Index() // invoke add patient
        {
            return View("AddPatient");
        }
        [HttpPost]
        public IActionResult AddtoDb(Patient obj) // save to Database
        {
            _db.Patients.Add(obj);   
            _db.SaveChanges();          
            
            return View("DisplayPatient");
        }
    }
}
