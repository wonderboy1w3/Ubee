using Ubee.Domain.Configurations;
using Ubee.Service.DTOs;
using Ubee.Service.Helpers;

namespace Ubee.Service.Interfaces;

public interface IWalletService
{
    ValueTask<Response<WalletDto>> AddWalletAsync(WalletForCreationDto walletForCreationDto);
    ValueTask<Response<WalletDto>> ModifyWalletAsync(long id, WalletForCreationDto walletForCreationDto);
    ValueTask<Response<bool>> DeleteWalletAsync(long id);
    ValueTask<Response<WalletDto>> GetWalletByIdAsync(long id);
    ValueTask<Response<List<WalletDto>>> GetAllWalletAsync();
}
