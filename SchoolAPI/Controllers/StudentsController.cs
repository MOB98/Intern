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
using Microsoft.AspNetCore.Authorization;

namespace SchoolAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly SchoolAPIContext _context;

        public StudentsController(SchoolAPIContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudent()
        {

            try
            {
               Program.log.Info("geting all the students...");
                return await _context.Students.ToListAsync();
               
            }
            catch (Exception)
            {
                Program.log.Error("could not get all the students");
                throw;
            }
         
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {

            Program.log.Info($"getting the Student with the Id = {id} founded");
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                Program.log.Error($"Student with the Id = {id} not found in the database");
                return NotFound();
            }
            Program.log.Info($"Student with the Id = {id} founded");
            return student;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                Program.log.Info($"Waiting for edit the student with Id = {id} in the database.. ");
                await _context.SaveChangesAsync();
                Program.log.Info($" student with Id = {id} Edited ");
            }   
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    Program.log.Error($"Student with the Id = {id} not found in the database");

                    return NotFound();
                }
                else
                {
                    Program.log.Error($"something happens while editing the student data");

                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            _context.Students.Add(student);
            try
            {
                Program.log.Info($"waiting for add a new student  ");
                await _context.SaveChangesAsync();
                Program.log.Info($"student with Id={student.Id} added to the database  ");
            }

            catch (DbUpdateException)
            {
                if (StudentExists(student.Id))
                {
                    Program.log.Error($" the student data conflict with the database");
                    return Conflict();
                }
                else
                {
                    Program.log.Error($" something happens: student can not be added with the database");

                    throw;
                }
            }
           

            return CreatedAtAction("GetStudent", new { id = student.Id   }, student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            Program.log.Info($"deleting the student with Id={id}...");
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                Program.log.Error($" student with Id={id} does not exist in the database...");
                return NotFound();
            }

            _context.Students.Remove(student);
            try { 
                await _context.SaveChangesAsync();
                Program.log.Info($" student with Id={id} deleted");
            }
            catch(Exception)
            {
                Program.log.Error($"something happens while deleting the student with Id={id} ");
                throw;
            }

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
