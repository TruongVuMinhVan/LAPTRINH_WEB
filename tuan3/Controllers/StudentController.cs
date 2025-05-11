using Microsoft.AspNetCore.Mvc;
using tuan3.Models;

namespace tuan3.Controllers
{
    public class StudentController : Controller
    {
        private static List<StudentController> registeredStudents = new List<StudentController>();
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult ShowKQ(StudentModel model)
        {
            StudentModel.DSDangKy.Add(model);
            int soLuong = StudentModel.DSDangKy.Count (s => s.Major == model.Major);
            ViewBag.soLuong = soLuong - 1;
            return View(model);
        }
    }
}
