using EfcoreApp.Data;
using EfcoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EfcoreApp.Controllers
{
    public class CourseController : Controller
    {
        private readonly DataContext _context;

        public CourseController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Course> courses = await _context.Courses.Include(c => c.Teacher).ToListAsync();
            return View(courses);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Teachers = new SelectList(await _context.Teachers.ToListAsync(), "TeacherId", "TeacherFullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseDTO model)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Add(new Course()
                {
                    CourseId = model.CourseId,
                    Title = model.Title,
                    TeacherId = model.TeacherId
                });
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Teachers = new SelectList(await _context.Teachers.ToListAsync(), "TeacherId", "TeacherFullName");

            return View(model);

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CourseDTO? course = await _context
                                .Courses
                                .Include(c => c.CourseRecords)
                                .ThenInclude(c => c.Student)
                                .Select(c => new CourseDTO
                                {
                                    CourseId = c.CourseId,
                                    Title = c.Title,
                                    TeacherId = c.TeacherId,
                                    CourseRecords = c.CourseRecords
                                })
                                .FirstOrDefaultAsync(c => c.CourseId == id);

            if (course == null)
            {
                return NotFound();
            }
            ViewBag.Teachers = new SelectList(await _context.Teachers.ToListAsync(), "TeacherId", "TeacherFullName");

            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CourseDTO model)

        {
            if (id != model.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(new Course()
                    {
                        CourseId = model.CourseId,
                        Title = model.Title,
                        TeacherId = model.TeacherId
                    });

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Students.Any(c => c.StudentId == model.CourseId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.Teachers = new SelectList(await _context.Teachers.ToListAsync(), "TeacherId", "TeacherFullName");
                return RedirectToAction("Index");
            }

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course? course = await _context.Courses.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            Course? course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}