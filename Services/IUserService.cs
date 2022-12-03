namespace API.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<List<User>> GetPart(int from, int to);
    }
}
