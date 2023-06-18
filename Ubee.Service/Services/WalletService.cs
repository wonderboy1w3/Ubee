using AutoMapper;
using Ubee.Service.DTOs;
using Ubee.Domain.Entities;
using Ubee.Data.IRepositories;
using Ubee.Service.Exceptions;
using Ubee.Service.Extensions;
using Ubee.Service.Interfaces;
using Ubee.Service.DTOs.Wallet;
using Ubee.Domain.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Ubee.Service.Services;

public class WalletService : IWalletService
{

    //I call the repository by constructor
    private readonly IMapper mapper;
    private readonly IUserService userService;
    private readonly IRepository<Wallet> walletRepository;
    public WalletService(IMapper mapper, 
        IUserService userService,
        IRepository<Wallet> walletRepository)
    {
        this.mapper = mapper;
        this.userService = userService;
        this.walletRepository = walletRepository;
    }

    public async ValueTask<WalletForResultDto> AddAsync(WalletForCreationDto walletForCreationDto)
    {
        // Check the user existing
        var user = await this.userService.RetrieveUserByIdAsync(walletForCreationDto.UserId);
        var mappedWallet = this.mapper.Map<Wallet>(walletForCreationDto);
        mappedWallet.CreatedAt = DateTime.UtcNow;
        var addedWallet = await this.walletRepository.InsertAsync(mappedWallet);
        await walletRepository.SaveAsync();
        return this.mapper.Map<WalletForResultDto>(addedWallet);
    }

 
    public async ValueTask<WalletForResultDto> ModifyAsync(WalletForUpdateDto dto)
    {
		var user = await this.userService.RetrieveUserByIdAsync(dto.UserId);
		var wallet = await this.walletRepository.SelectAsync(w=>w.Id == dto.Id);
        if (wallet is null || wallet.IsDeleted)
            throw new CustomException(404, "Wallet is not found");

        var mapped = mapper.Map(dto,wallet);
        mapped.UpdatedAt = DateTime.UtcNow;
        await walletRepository.SaveAsync();
        return this.mapper.Map<WalletForResultDto>(mapped);
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var wallet = await walletRepository.DeleteAysnyc(w => w.Id == id);
        if (!wallet)
            throw new CustomException(404, "Couldn't find user for this given Id");
        
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
        if (wallet is null)
            throw new CustomException(404, "Wallet is not found");
        return mapper.Map<WalletForResultDto>(wallet);
    }
}
