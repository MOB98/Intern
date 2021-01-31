using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Models
{
    public class Student
    {  
    
        [Key]
      
        public int Id { get; set; }
        [Required]
        public string name { get; set; }

        [Required]
        public string phonenumber { get; set; }

        [Required]
        public string address { get; set; }

       
        public ICollection<AssignedCourse> assignedCourses { get; set; }






        //   [Required]
        //  public string password { get; set; }
        //[Required]
        // public string email { get; set; }
        //[Required]
        // public List<Course> courses;

    }
}
