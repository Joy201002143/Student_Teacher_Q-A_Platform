using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacherQnA.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(100)]
        [MaxLengthAttribute(100)]
        [Required]
        public string Name { get; set; } // For Every user full name must be needed
    }
}
