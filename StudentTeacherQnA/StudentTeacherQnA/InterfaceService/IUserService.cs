namespace StudentTeacherQnA.InterfaceService
{
    public interface IUserService
    {
        string? GetUserId { get; }
        bool? IsAuthenticated { get; }
        string? GetUserName(string UserID);
        public Task<List<(string, string, string)>> GetRespondedQA(string UserID);
    }
}
