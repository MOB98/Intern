using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DEMO.Areas.Identity.Data
{
    public class StudentModel : Microsoft.AspNet.Identity.EntityFramework.IdentityUser
    {



        [Required]
        [PersonalData]
        public string Firstname { get; set; }

        [Required]
        [PersonalData]
        public string Lastname { get; set; }
    }
       
}
