using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Models
{
    public class Course
    {
        [Key]
    
        public int Id { get; set; }

        [Required]
        public string courseName { get; set; }
   //     public ICollection<Teacher> teachers { get; set; }

   
    }
}



//Admin=> createcourse,add ,edit,delete
//teachers=>displaycoursesteacher,displaystudent and course info,
//students=>displaycourses,displaycourse info