using Ubee.Domain.Enums;

namespace Ubee.Service.DTOs.Transactions;
public class TransactionForCreationDto
{
    public decimal Amount { get; set; }
    public string Note { get; set; }
    public TransactionType Type { get; set; }
    public long WalletId { get; set; }
}
