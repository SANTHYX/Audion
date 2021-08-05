using Application.Dto.User;
using System;
using System.Threading.Tasks;

namespace Application.Commons.Services
{
    public interface IUserService
    {
        Task<GetUserDto> GetAsync(string userName);
    }
}
