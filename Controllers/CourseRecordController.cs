using EfcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EfcoreApp.Controllers
{
    public class CourseRecordController : Controller
    {
        private readonly DataContext _context;
        public CourseRecordController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<CourseRecord> records = await _context.
                                            CourseRecords.
                                            Include(x => x.Student).
                                            Include(x => x.Course).
                                            ToListAsync();

            return View(records);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Students = new SelectList(await _context.Students.ToListAsync(), "StudentId", "StudentFullName");
            ViewBag.Courses = new SelectList(await _context.Courses.ToListAsync(), "CourseId", "Title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseRecord model)
        {
            model.RecordDate = DateTime.Now;
            _context.CourseRecords.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}