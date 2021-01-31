using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Models
{
    public class AssignedCourse
    {
        [Key]
        
        public int Id { get; set; }
        
        [Required]
        public string courseDate { get; set; }

        public Course course { get; set; }
        public Teacher teacher { get; set; }
        public ICollection<Student> student { get; set; }
        

    }
}