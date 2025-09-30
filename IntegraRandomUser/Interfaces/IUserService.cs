using IntegraRandomUser.DTOs;

namespace IntegraRandomUser.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO?> GetUserAsync();
    }
}
