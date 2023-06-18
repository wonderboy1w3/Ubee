using Ubee.Service.DTOs;
using Ubee.Service.DTOs.Wallet;
using Ubee.Domain.Configurations;

namespace Ubee.Service.Interfaces;

public interface IWalletService
{
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<WalletForResultDto> RetrieveByIdAsync(long id);
    ValueTask<WalletForResultDto> AddAsync(WalletForCreationDto dto);
    ValueTask<WalletForResultDto> ModifyAsync(WalletForUpdateDto dto);
    ValueTask<IEnumerable<WalletForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
