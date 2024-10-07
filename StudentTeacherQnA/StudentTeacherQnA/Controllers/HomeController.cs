//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using StudentTeacherQnA.Data;
//using System.Linq;

//namespace StudentTeacherQnA.Controllers
//{
//    public class HomeController : Controller
//    {
//        private readonly AppDbContext _context;

//        public HomeController(AppDbContext context)
//        {
//            _context = context;
//        }

//        public IActionResult Index()
//        {
//            var questions = _context.Questions
//                .Include(q => q.AskedBy)
//                .Include(q => q.Answers)
//                .OrderByDescending(q => q.CreatedAt)
//                .ToList();

//            return View(questions); // Pass questions to the view
//        }
//    }
//}
