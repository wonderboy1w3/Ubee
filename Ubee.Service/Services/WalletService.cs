using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Ubee.Data.IRepositories;
using Ubee.Data.Repositories;
using Ubee.Domain.Entities;
using Ubee.Service.DTOs;
using Ubee.Service.Helpers;
using Ubee.Service.Interfaces;

namespace Ubee.Service.Services;

public class WalletService : IWalletService
{
    private readonly IWalletRepository walletRepository = new WalletRepository();
    private readonly IUserRepository userRepository = new UserRepository();
    private readonly IMapper mapper;
    public WalletService(IMapper mapper)
    {
        this.mapper = mapper;
    }

    public async ValueTask<Response<WalletDto>> AddWalletAsync(WalletForCreationDto walletForCreationDto)
    {
        var user = await this.walletRepository.SelectWalletAsync(u => u.Id == walletForCreationDto.UserId);

        if (user is null)
            return new Response<WalletDto>
            {
                Code = 404,
                Message = "Wallet not found",
                Value = null
            };


        var mappedWallet = this.mapper.Map<Wallet>(walletForCreationDto);
        var addedWallet = await this.walletRepository.InsertWalletAsync(mappedWallet);
        var resultDto = this.mapper.Map<WalletDto>(addedWallet);
        return new Response<WalletDto>
        {
            Code = 200,
            Message = "Success",
            Value = resultDto
        };
    }

    public async ValueTask<Response<bool>> DeleteWalletAsync(long id)
    {
        Wallet wallet = await this.walletRepository.SelectWalletAsync(w => w.Id.Equals(id));
        if (wallet is null)
            return new Response<bool>
            {
                Code = 404,
                Message = "Couldn't find for given ID",
                Value = false
            };

        await this.walletRepository.DeleteWalletAysnyc(id);
        return new Response<bool>
        {
            Code = 200,
            Message = "Success",
            Value = true
        };
    }

    public async ValueTask<Response<List<WalletDto>>> GetAllWalletAsync()
    {
        var wallets = await walletRepository.SelectAllWallets().ToListAsync();
        var mappedWallets = mapper.Map<List<WalletDto>>(wallets);

        return new Response<List<WalletDto>>
        {
            Code = 200,
            Message = "Success",
            Value = mappedWallets
        };
    }

    public async ValueTask<Response<WalletDto>> GetWalletByIdAsync(long id)
    {
        Wallet wallet = await this.walletRepository.SelectWalletAsync(w => w.Id.Equals(id));
        if (wallet is null)
            return new Response<WalletDto>
            {
                Code = 404,
                Message = "Couldn't find for given ID",
                Value = null
            };

        var mappedWallets = this.mapper.Map<WalletDto>(wallet);
        return new Response<WalletDto>
        {
            Code = 200,
            Message = "Success",
            Value = mappedWallets
        };
    }

    public async ValueTask<Response<WalletDto>> ModifyWalletAsync(long id, WalletForCreationDto walletForCreationDto)
    {
        Wallet wallet = await this.walletRepository.SelectWalletAsync(w => w.Id.Equals(id));
        if (wallet is null)
            return new Response<WalletDto>
            {
                Code = 404,
                Message = "Couldn't find for given ID",
                Value = null
            };

        var updatedWallet = await this.walletRepository.UpdateWalletAsync(wallet);
        var mappedWallet = this.mapper.Map<WalletDto>(updatedWallet);
        return new Response<WalletDto>
        {
            Code = 200,
            Message = "Success",
            Value = mappedWallet
        };
    }
}
