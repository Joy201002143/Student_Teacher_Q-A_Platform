using System.ComponentModel.DataAnnotations;

namespace StudentTeacherQnA.Models
{
	public class LoginJM
	{
		[Required(ErrorMessage = "Email is required")]// Stores the user's email for login
		public string Email { get; set; }
		[Required(ErrorMessage = "Password is required")]// Stores the user's password
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "Remember Me")]
		public bool RememberMe { get; set; } // Option to remember login credentials

		[Required]
		[Display(Name = "Account Type")]
		public string UserRole { get; set; }  // Stores the type of user account (e.g., Student, Teacher)
	}
}
