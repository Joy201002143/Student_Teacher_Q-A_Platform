namespace StudentTeacherQnA.Models
{
	// This class represents the model used for handling error information in the application.
	public class ErrorViewModel
	{
		// Property to store the unique Request ID, which helps track the request that caused an error.
		// The '?' allows this property to hold a null value (nullable string).
		public string? RequestId { get; set; }
		// This property returns true if the RequestId is not null or empty.
		// It's a helper property to determine whether to show the RequestId in the error view.
		public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
	}
}
