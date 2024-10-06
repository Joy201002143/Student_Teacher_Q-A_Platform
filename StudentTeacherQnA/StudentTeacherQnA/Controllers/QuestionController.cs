using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentTeacherQnA.Data;
using StudentTeacherQnA.Models;
using System.Linq;

namespace StudentTeacherQnA.Controllers
{
    public class QuestionController : Controller
    {
        private readonly AppDbContext _context;

        public QuestionController(AppDbContext context)
        {
            _context = context;
        }

        // Action to display the form to edit a question
        public IActionResult Edit(int id)
        {
            // Find the question by its ID
            var question = _context.Questions.Find(id);

            // If the question is not found, return 404 (Not Found)
            if (question == null)
            {
                return NotFound();  // Return 404 if the question doesn't exist
            }

            return View(question);
        }

        // Action to submit the edited question
        [HttpPost]
        public IActionResult Edit(Question question)
        {
            if (ModelState.IsValid)
            {
                // Mark the entity as modified
                _context.Entry(question).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View(question);
        }

        // Action to display the form to delete a question
        public IActionResult Delete(int id)
        {
            // Find the question by its ID, including related answers
            var question = _context.Questions.Include(q => q.Answers).FirstOrDefault(q => q.QuestionId == id);

            // If the question is not found, return 404 (Not Found)
            if (question == null)
            {
                return NotFound();  // Return 404 if the question doesn't exist
            }

            return View(question);
        }

        // Action to confirm the deletion of a question
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            // Find the question by its ID
            var question = _context.Questions.Find(id);

            // If the question is not found, return 404 (Not Found)
            if (question == null)
            {
                return NotFound();  // Return 404 if the question doesn't exist
            }

            // Remove the question and save changes
            _context.Questions.Remove(question);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
    }
}
