using Ubee.Domain.Commons;
using Ubee.Domain.Enums;

namespace Ubee.Domain.Entities;

public class Transaction : Auditable
{
    public long CategoryDetailId { get; set; }
    public CategoryDetail CategoryDetail { get; set; }
    public long WalletId { get; set; }
    public Wallet Wallet { get; set; }
    public decimal Amount { get; set; }
    public string Note { get; set; }
    public TransactionType Type { get; set; }
}
