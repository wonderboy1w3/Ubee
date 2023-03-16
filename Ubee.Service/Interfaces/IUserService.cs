using Ubee.Domain.Configurations;
using Ubee.Service.DTOs;
using Ubee.Service.Helpers;

namespace Ubee.Service.Interfaces;

public interface IUserService 
{
    ValueTask<Response<UserDto>> AddUserAsync(UserForCreationDto userForCreationDto);
    ValueTask<Response<UserDto>> ModifyUserAsync(long id, UserForCreationDto userForCreationDto);
    ValueTask<Response<bool>> DeleteUserAsync(long id);
    ValueTask<Response<UserDto>> GetUserByIdAsync(long id);
    ValueTask<Response<List<UserDto>>> GetAllUserAsync(PaginationParams @params, string search = null);
}
