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
        public async Task<List<User>> GetAllUsers()
        {
            return await _dataContext.LoadJson();
        }

        public async Task<List<User>> GetPart(int from, int to)
        {
            var data = await _dataContext.LoadJson();
            
            if(from < to)
            {
                var sortedUsers = data.Where(id => id.Id >= from && id.Id <= to).ToList();
                return sortedUsers;
            }
            if (from > to)
            {
                var sortedUsers = data.Where(id => id.Id <= from && id.Id >= to).OrderByDescending(o => o.Id).ToList();
                return sortedUsers;
            }

            var user = data.Where(id => id.Id == from).ToList();

            return user;
        }
    }
}
