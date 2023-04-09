using Ubee.Domain.Enums;

namespace Ubee.Service.DTOs;
public class TransactionDto
{
    public decimal Amount { get; set; }
    public string Note { get; set; }
    public TransactionType Type { get; set; }
    public long WalletId { get; set; }
}