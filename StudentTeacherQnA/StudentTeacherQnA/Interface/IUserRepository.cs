namespace StudentTeacherQnA.Interface
{
    public interface IUserRepository // Use 'interface' keyword instead of 'class'
    {
        string? GetUserName(string UserID); // No access modifier, just the method signature
        Task<List<(string, string, string)>> GetRespondedQA(string UserID); // Same here, no 'public'
    }
}
