using Application.Dto.User;
using System;
using System.Threading.Tasks;

namespace Application.Commons.Services
{
    public interface IUserService : IService
    {
        Task<GetUserDto> GetAsync(string userName);
    }
}
