using System.ComponentModel.DataAnnotations;

namespace StudentTeacherQnA.Models
{
	public class StudentRegisterJM
	{
		[Required(ErrorMessage = "Name is required")]
		public string Name { get; set; } // Stores the student's name

		[Required(ErrorMessage = "Institute Name is required")]
		[Display(Name = "University Name")]
		public string InstituteName { get; set; } // Stores the name of the student's institute

		[Required(ErrorMessage = "ID Card Number is required")]
		[Display(Name = "ID Card Number")]
		public int InstituteIdCardNumber { get; set; } // Stores the student's institute ID card number

		[Required(ErrorMessage = "Email is required")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; } // Stores the student's email address

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; } // Stores the student's password

		[Compare("Password", ErrorMessage = "Password and Confirm Password do not match")]
		[Display(Name = "Confirm Password")]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; } // Ensures the confirm password matches the original password
	}
}
