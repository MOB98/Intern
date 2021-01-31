using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DEMO.Areas.Identity.Data
{
   
    public class TeacherModel
    {
       
        [Required]
        [PersonalData]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }

    }
}
