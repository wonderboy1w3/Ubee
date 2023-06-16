using Ubee.Service.DTOs.Users;
using Ubee.Domain.Configurations;

namespace Ubee.Service.Interfaces;

public interface IUserService 
{
    ValueTask<bool> RemoveUserAsync(long id);
    ValueTask<UserForResultDto> RetrieveUserByIdAsync(long id);
    ValueTask<UserForResultDto> ModifyUserAsync(UserForUpdateDto userForUpdateDto);
    ValueTask<UserForResultDto> AddUserAsync(UserForCreationDto userForCreationDto);
    ValueTask<IEnumerable<UserForResultDto>> RetrieveAllUserAsync(PaginationParams @params, string search = null);
}
