using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DEMO.Models;
using SchoolAPI.Data;
using SchoolAPI.Models;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly SchoolAPIContext _context;

        public CoursesController(SchoolAPIContext context)
        {
            _context = context;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourse()
        {
            try
            {
                    Program.log.Info("geting all the courses...");
                return await _context.Courses.ToListAsync();

            }
            catch (Exception)
            {
                Program.log.Error("could not get all the courses");
                throw;
            }
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            Program.log.Info($"getting the Course with the Id = {id} founded");
            var courses = await _context.Courses.ToListAsync();//Include(co => co.teacher).
            var course = courses.Find(co => co.Id == id);

            if (course == null)
            {
                Program.log.Error($"Course with the Id = {id} not found in the database");
                return NotFound();
            }
            Program.log.Info($"Course with the Id = {id} founded");

            return course;
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, Course course)
        {
            if (id != course.Id)
            {
                return BadRequest();
            }

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                Program.log.Info($"Waiting for edit the Course with Id = {id} in the database.. ");
                await _context.SaveChangesAsync();
                Program.log.Info($" Course with Id = {id} Edited ");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                        Program.log.Error($"Course with the Id = {id} not found in the database");
                    return NotFound();
                }
                else
                {
                    Program.log.Error($"something happens while editing the Course data");
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {

          //  var teacher = _context.Teacher.Find(course.teachers.ToList().Find(tr=>tr.Id));
         //   course.teacher = teacher;
            _context.Courses.Add(course);
            try
            {
                Program.log.Info($"waiting for add a new teacher  ");
                await _context.SaveChangesAsync();
                Program.log.Info($"course with Id={course.Id} added to the database  ");

            }
            catch (DbUpdateException)
            {
                if (CourseExists(course.Id))
                {
                    Program.log.Error($" the course data conflict with the database");
                    return Conflict();
                }
                else
                {
                    Program.log.Error($" something happens: course can not be added with the database");
                    throw;
                }
            }

            return CreatedAtAction("GetCourse", new { id = course.Id }, course);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            Program.log.Info($"deleting the course with Id={id}...");
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                Program.log.Error($" course with Id={id} does not exist in the database...");
                return NotFound();
            }

            _context.Courses.Remove(course);
            try
            {
                await _context.SaveChangesAsync();
                Program.log.Info($" course with Id={id} deleted");

            }
            catch (Exception)
            {
                Program.log.Error($"something happens while deleting the course with Id={id} ");
                throw;
            }


            return NoContent();
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }
    }
}
