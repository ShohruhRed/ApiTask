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

            if(data == null)
            {
                throw new ArgumentException("No data avialable");
            }
            
            if(from < to)
            {
                var sortedUsers = data.Where(id => id.Id >= from && id.Id <= to).ToList();

                if(sortedUsers.Count == 0)
                    throw new ArgumentException("There is no data in this interval");

                return sortedUsers;
            }
            if (from > to)
            {
                var sortedUsers = data.Where(id => id.Id <= from && id.Id >= to).OrderByDescending(o => o.Id).ToList();

                if (sortedUsers.Count == 0)
                    throw new ArgumentException("There is no data in this interval");

                return sortedUsers;
            }
            
            /* if FROM and TO are equal return one user */

            var user = data.Where(id => id.Id == from).ToList();

            if (user.Count == 0)
                throw new ArgumentException("There is no data in this interval");

            return user;
        }
    }
}
