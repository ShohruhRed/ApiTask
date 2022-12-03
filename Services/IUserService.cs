namespace API.Services
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
    }
}
