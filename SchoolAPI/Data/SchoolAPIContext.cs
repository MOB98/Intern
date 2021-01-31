using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DEMO.Models;

namespace SchoolAPI.Data
{
    public class SchoolAPIContext : DbContext
    {
        public SchoolAPIContext (DbContextOptions<SchoolAPIContext> options)
            : base(options)
        {
        }

        public DbSet<SchoolAPI.Models.AssignedCourse> AssignedCourses { get; set; }

        public DbSet<SchoolAPI.Models.Course> Courses { get; set; }

        public DbSet<SchoolAPI.Models.Student> Students { get; set; }

        public DbSet<SchoolAPI.Models.Teacher> Teachers { get; set; }
        //public DbSet<SchoolAPI.Models.TeacherModel> TeacherAuths { get; set; }
        //public DbSet<SchoolAPI.Models.StudentModel> StudentAuths { get; set; }
        //public DbSet<SchoolAPI.Models.AdminModel> AdminAuths { get; set; }


    }
}
