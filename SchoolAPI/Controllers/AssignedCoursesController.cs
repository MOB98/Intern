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
            try
            {
                Program.log.Info("geting all the Assigned courses...");
                return await _context.AssignedCourses.ToListAsync();
            }

            catch (Exception)
            {
                Program.log.Error("could not get all the Assigned courses");
                throw;
            }
        }


        // GET: api/AssignedCourses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AssignedCourse>> GetAssignedCourse(int id)
        {
            Program.log.Info($"getting the Assigned Course with the Id = {id} founded");
            var assignedCourse = await _context.AssignedCourses.FindAsync(id);

            if (assignedCourse == null)
            {
                Program.log.Error($"Assigned Course with the Id = {id} not found in the database");
                return NotFound();
            }
            Program.log.Info($"Assigned Course with the Id = {id} founded");


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
                Program.log.Info($"Waiting for edit the Assigned Course with Id = {id} in the database.. ");
                await _context.SaveChangesAsync();
                Program.log.Info($" Assigned Course with Id = {id} Edited ");
    
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignedCourseExists(id))
                {
                    Program.log.Error($"Assigned Course with the Id = {id} not found in the database");
                    return NotFound();
                }
                else
                {
                    Program.log.Error($"something happens while editing the Assigned Course data");
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
            try
            {
                Program.log.Info($"waiting for add a new assigned course  ");
                await _context.SaveChangesAsync();
                Program.log.Info($"assigned course with Id={assignedCourse.Id} added to the database  ");

            }
            catch (DbUpdateException)
            {
                if (AssignedCourseExists(assignedCourse.Id))
                {
                    Program.log.Error($" the assigned course data conflict with the database");
                    return Conflict();
                }
                else
                {
                    Program.log.Error($" something happens: assigned course can not be added with the database");
                    throw;
                }

            }     return CreatedAtAction("GetAssignedCourse", new { id = assignedCourse.Id }, assignedCourse);
        }

        // DELETE: api/AssignedCourses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignedCourse(int id)
        {
            var assignedCourse = await _context.AssignedCourses.FindAsync(id);
            if (assignedCourse == null)
            {
                Program.log.Error($" assigned course with Id={id} does not exist in the database...");
                return NotFound();
            }

            _context.AssignedCourses.Remove(assignedCourse);
            try
            {
                await _context.SaveChangesAsync();
                Program.log.Info($" assigned course with Id={id} deleted");
            }

            catch (Exception)
            {
                Program.log.Error($"something happens while deleting the assigned course with Id={id} ");
                throw;
            }


            return NoContent();
        }

        private bool AssignedCourseExists(int id)
        {
            return _context.AssignedCourses.Any(e => e.Id == id);
        }
    }
}
