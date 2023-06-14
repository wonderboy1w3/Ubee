using AutoMapper;
using Ubee.Data.IRepositories;
using Ubee.Data.Repositories;
using Ubee.Domain.Configurations;
using Ubee.Domain.Entities;
using Ubee.Service.DTOs;
using Ubee.Service.Extensions;
using Ubee.Service.Helpers;
using Ubee.Service.Interfaces;

namespace Ubee.Service.Services;
public class TransactionService : ITransactionService
{
    private readonly IRepository<Wallet> walletRepository;
    private readonly IMapper mapper;
    public TransactionService(IMapper mapper, IRepository<Wallet> walletRepository)
    {
        this.mapper = mapper;
        this.walletRepository = walletRepository;
    }

    public async ValueTask<Response<TransactionDto>> AddTransactionAsync(TransactionForCreationDto transactionForCreationDto)
    {
        if(transactionForCreationDto.Type == Domain.Enums.TransactionType.Income)
        {
            var res = await this.walletRepository.SelectAsync(wl => wl.Id == transactionForCreationDto.WalletId);
            if(res is null)
            {
                return new Response<TransactionDto>
                {
                    Code = 404 ,
                    Message = "Not found",
                    Value = null
                };
            }
            res.AvailableMoney += transactionForCreationDto.Amount;
            await this.walletRepository.UpdateAsync(res);
            var mappedRes = mapper.Map<TransactionDto>(transactionForCreationDto);
            return new Response<TransactionDto>
            {
                Code = 200,
                Message = "Success",
                Value = mappedRes
            };
        }
        else
        {
            var res = await this.walletRepository.SelectAsync(wl => wl.Id == transactionForCreationDto.WalletId);
            if (res is null)
            {
                return new Response<TransactionDto>
                {
                    Code = 404,
                    Message = "Not found",
                    Value = null
                };
            }
            if (res.AvailableMoney < transactionForCreationDto.Amount)
            {
                return new Response<TransactionDto>
                {
                    Code = 404,
                    Message = "There are insufficient funds in your account",
                    Value = null
                };
            }
            res.AvailableMoney -= transactionForCreationDto.Amount;
            await this.walletRepository.UpdateAsync(res);
            var mappedRes = mapper.Map<TransactionDto>(transactionForCreationDto);
            return new Response<TransactionDto>
            {
                Code = 200,
                Message = "Success",
                Value = mappedRes
            };

        }

    }

    public async ValueTask<Response<bool>> DeleteTransactionAsync(long id)
    {
        Transaction user = await this.transactionRepository.SelectTransactionById(user => user.Id.Equals(id));
        if (user is null)
            return new Response<bool>
            {
                Code = 404,
                Message = "Couldn't find for given ID",
                Value = false
            };

        await this.transactionRepository.DeleteTransactionAysnyc(id);
        return new Response<bool>
        {
            Code = 200,
            Message = "Success",
            Value = true
        };
    }

    public async ValueTask<Response<List<TransactionDto>>> GetAllTransactionAsync()
    {
        var transactions = transactionRepository.SelectAllTransactions().ToList();
        var mappedWallets = mapper.Map<List<TransactionDto>>(transactions);

        return new Response<List<TransactionDto>>
        {
            Code = 200,
            Message = "Success",
            Value = mappedWallets
        };
    }

    public async ValueTask<Response<TransactionDto>> GetTransactionByIdAsync(long id)
    {
        Transaction user = await this.transactionRepository.SelectTransactionById(tr => tr.Id.Equals(id));
        if (user is null)
            return new Response<TransactionDto>
            {
                Code = 404,
                Message = "Couldn't find for given ID",
                Value = null
            };

        var mappedUsers = this.mapper.Map<TransactionDto>(user);
        return new Response<TransactionDto>
        {
            Code = 200,
            Message = "Success",
            Value = mappedUsers
        };
    }

    public async ValueTask<Response<TransactionDto>> ModifyTransactionAsync(long id, TransactionForCreationDto transactionForCreationDto)
    {
        Transaction user = await this.transactionRepository.SelectTransactionById(tr => tr.Id.Equals(id));
        if (user is null)
            return new Response<TransactionDto>
            {
                Code = 404,
                Message = "Couldn't find for given ID",
                Value = null
            };

        var updatedUser = await this.transactionRepository.UpdateTransactionAsync(user);
        var mappedUsers = this.mapper.Map<TransactionDto>(updatedUser);
        return new Response<TransactionDto>
        {
            Code = 200,
            Message = "Success",
            Value = mappedUsers
        };
    }
}
