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
    public class TeachersController : ControllerBase
    {
        private readonly SchoolAPIContext _context;

        public TeachersController(SchoolAPIContext context)
        {
            _context = context;
        }

        // GET: api/Teachers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeacher()
        {
            return await _context.Teachers.ToListAsync();
        }

        // GET: api/Teachers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacher(int id)
        {
            Program.log.Info($"getting the Teacher with the Id = {id} founded");
            var teacher = await _context.Teachers.FindAsync(id);

            if (teacher == null)
            {
                Program.log.Error($"Teacher with the Id = {id} not found in the database");
                return NotFound();
            }
            Program.log.Info($"Teacher with the Id = {id} founded");
            return teacher;
        }

        // PUT: api/Teachers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher(int id, Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return BadRequest();
            }

            _context.Entry(teacher).State = EntityState.Modified;

            try
            {
                Program.log.Info($"Waiting for edit the Teacher with Id = {id} in the database.. ");
                await _context.SaveChangesAsync();
                Program.log.Info($" Teacher with Id = {id} Edited ");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherExists(id))
                {
                    Program.log.Error($"Teacher with the Id = {id} not found in the database");
                    return NotFound();
                }
                else
                {
                    Program.log.Error($"something happens while editing the Teacher data");
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Teachers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Teacher>> PostTeacher(Teacher teacher)
        {

            _context.Teachers.Add(teacher);

            try
            {
                Program.log.Info($"waiting for add a new teacher  ");
                await _context.SaveChangesAsync();
                Program.log.Info($"teacher with Id={teacher.Id} added to the database  ");

            }
            catch (DbUpdateException)
            {
                if (TeacherExists(teacher.Id))
                {
                    Program.log.Error($" the teacher data conflict with the database");
                    return Conflict();
                }
                else
                {
                    Program.log.Error($" something happens: teacher can not be added with the database");

                    throw;
                }
            }
            
           
            return CreatedAtAction("GetTeacher", new { id = teacher.Id }, teacher);
        }

        // DELETE: api/Teachers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            Program.log.Info($"deleting the teacher with Id={id}...");
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                Program.log.Error($" teacher with Id={id} does not exist in the database...");

                return NotFound();
            }

            _context.Teachers.Remove(teacher);
            try
            {
                await _context.SaveChangesAsync();
                Program.log.Info($" teacher with Id={id} deleted");
            }


            catch (Exception) {
                Program.log.Error($"something happens while deleting the teacher with Id={id} ");
                throw;
            }
           

            return NoContent();
        }

        private bool TeacherExists(int id)
        {
            return _context.Teachers.Any(e => e.Id == id);
        }
    }
}
