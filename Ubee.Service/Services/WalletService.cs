using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Ubee.Data.IRepositories;
using Ubee.Domain.Configurations;
using Ubee.Domain.Entities;
using Ubee.Service.DTOs;
using Ubee.Service.DTOs.Users;
using Ubee.Service.DTOs.Wallet;
using Ubee.Service.Exceptions;
using Ubee.Service.Extensions;
using Ubee.Service.Interfaces;

namespace Ubee.Service.Services;

public class WalletService : IWalletService
{

    //I call the repository by constructor
    private readonly IRepository<Wallet> walletRepository;
    private readonly IMapper mapper;
    public WalletService(IRepository<Wallet> walletRepository, IMapper mapper)
    {
        this.walletRepository = walletRepository;
        this.mapper = mapper;
    }

    public async ValueTask<WalletForResultDto> AddAsync(WalletForCreationDto walletForCreationDto)
    {
        var user = await this.walletRepository.SelectAsync(u => u.Id == walletForCreationDto.UserId);

        if (user is not null)
            throw new CustomException(409, "Wallet already exist");


        var mappedWallet = this.mapper.Map<Wallet>(walletForCreationDto);
        var addedWallet = await this.walletRepository.InsertAsync(mappedWallet);
        await walletRepository.SaveAsync();
        return this.mapper.Map<WalletForResultDto>(addedWallet);
    }

 
    public async ValueTask<WalletForResultDto> ModifyAsync(long id, WalletForUpdateDto dto)
    {
        var wallet = await this.walletRepository.SelectAsync(w=>w.Id == id);
        if (wallet is null || wallet.IsDeleted)
            throw new CustomException(404, "Wallet not found");

        var mapped = mapper.Map(dto,wallet);
        mapped.UpdatedAt = DateTime.UtcNow;
        await walletRepository.SaveAsync();
        return this.mapper.Map<WalletForResultDto>(mapped);
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var entity = await walletRepository.SelectAsync(w => w.Id == id);
        if (entity is null || entity.IsDeleted)
            throw new CustomException(404, "Couldn't find user for this given Id");

        await walletRepository.DeleteAysnyc(w=>w.Id== id);
        await walletRepository.SaveAsync();
        return true;
    }

    public async ValueTask<IEnumerable<WalletForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var wallets = await walletRepository.SelectAll()
            .Where(u => u.IsDeleted == false)
            .ToPagedList(@params)
            .ToListAsync();

        return mapper.Map<IEnumerable<WalletForResultDto>>(wallets);
    }

    public async ValueTask<WalletForResultDto> RetrieveByIdAsync(long id)
    {
        var wallet = await this.walletRepository.SelectAsync(w=>w.Id == id);
        if (wallet is null || wallet.IsDeleted)
            throw new CustomException(404, "Wallet not found");
        return mapper.Map<WalletForResultDto>(wallet);
    }
}
