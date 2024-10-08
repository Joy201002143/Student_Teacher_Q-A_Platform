using System.ComponentModel.DataAnnotations;

namespace StudentTeacherQnA.Models
{
	public class TeacherRegistrationJM
    {
		[Required(ErrorMessage = "Name is required")]
		public string Name { get; set; } // Stores the user's name

		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; } // Stores the user's email

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; } // Stores the user's password

		[Compare("Password", ErrorMessage = "Password and Confirm Password do not match")]
		[Display(Name = "Confirm Password")]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; } // Ensures the confirm password matches the original password
	}

}
