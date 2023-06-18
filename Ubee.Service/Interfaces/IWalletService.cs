using Ubee.Service.DTOs;
using Ubee.Domain.Configurations;
using Ubee.Service.DTOs.Wallet;

namespace Ubee.Service.Interfaces;

public interface IWalletService
{
    ValueTask<WalletForResultDto> AddAsync(WalletForCreationDto dto);
    ValueTask<WalletForResultDto> ModifyAsync(long id, WalletForUpdateDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<WalletForResultDto> RetrieveByIdAsync(long id);
    ValueTask<IEnumerable<WalletForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
