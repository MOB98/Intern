using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DEMO.Models
{
    public class AssignedCourse
    {


        [Key]

        public int Id { get; set; }

        [Required]
        public string courseDate { get; set; }

        [ForeignKey("Courses")]
        public int courseID { get; set; }
        public  Course course { get; set; }

        [ForeignKey("Teachers")]
        public int teacherID { get; set; }
        public  Teacher teacher { get; set; }
        //public ICollection<Student> student { get; set; }

    }

   

}