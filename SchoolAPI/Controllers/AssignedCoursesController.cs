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
    public class AssignedCoursesController : ControllerBase
    {
        private readonly SchoolAPIContext _context;

        public AssignedCoursesController(SchoolAPIContext context)
        {
            _context = context;
        }

        // GET: api/AssignedCourses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssignedCourse>>> GetAssignedCourse()
        {
            return await _context.AssignedCourses.ToListAsync();
        }

        // GET: api/AssignedCourses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AssignedCourse>> GetAssignedCourse(int id)
        {
            var assignedCourse = await _context.AssignedCourses.FindAsync(id);

            if (assignedCourse == null)
            {
                return NotFound();
            }

            return assignedCourse;
        }

        // PUT: api/AssignedCourses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssignedCourse(int id, AssignedCourse assignedCourse)
        {
            if (id != assignedCourse.Id)
            {
                return BadRequest();
            }

            _context.Entry(assignedCourse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignedCourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AssignedCourses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AssignedCourse>> PostAssignedCourse(AssignedCourse assignedCourse)
        {
            _context.AssignedCourses.Add(assignedCourse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssignedCourse", new { id = assignedCourse.Id }, assignedCourse);
        }

        // DELETE: api/AssignedCourses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignedCourse(int id)
        {
            var assignedCourse = await _context.AssignedCourses.FindAsync(id);
            if (assignedCourse == null)
            {
                return NotFound();
            }

            _context.AssignedCourses.Remove(assignedCourse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AssignedCourseExists(int id)
        {
            return _context.AssignedCourses.Any(e => e.Id == id);
        }
    }
}
