using StudentTeacherQnA.Interface;
using StudentTeacherQnA.InterfaceService;
using System.Security.Claims;

namespace StudentTeacherQnA.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;

        public UserService(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
            //I add x for test purpose and there is no user information here.
            var x = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

        }


        public string? GetUserId
        {
            get
            {
                var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
                return userIdClaim;
            }
        }

        public bool? IsAuthenticated => GetUserId != null;

        public async Task<List<(string, string, string)>> GetRespondedQA(string UserID)
        {
            var respondedQA = await _userRepository.GetRespondedQA(UserID);

            return respondedQA;
        }

        public string? GetUserName(string UserID)
        {
            string? name = _userRepository.GetUserName(UserID);
            return name;
        }


    }
}
