using API.Data;

namespace API.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _dataContext;

        public UserService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<User>> GetUsers()
        {
            return await _dataContext.LoadJson();
        }
    }
}
