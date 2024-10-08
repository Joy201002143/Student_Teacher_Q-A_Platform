namespace StudentTeacherQnA.Interface
{
    public class IUserRepository
    {
        string? GetUserName(string UserID);
        public Task<List<(string, string, string)>> GetRespondedQA(string UserID);
    }
}
