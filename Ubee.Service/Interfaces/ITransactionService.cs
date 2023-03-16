using Ubee.Domain.Configurations;
using Ubee.Service.DTOs;
using Ubee.Service.Helpers;

namespace Ubee.Service.Interfaces;

public interface ITransactionService
{
    ValueTask<Response<TransactionDto>> AddTransactionAsync(TransactionForCreationDto transactionForCreationDto);
    ValueTask<Response<TransactionDto>> ModifyTransactionAsync(long id, TransactionForCreationDto transactionForCreationDto);
    ValueTask<Response<bool>> DeleteTransactionAsync(long id);
    ValueTask<Response<TransactionDto>> GetTransactionByIdAsync(long id);
    ValueTask<Response<List<TransactionDto>>> GetAllTransactionAsync(PaginationParams @params, string search = null);
}