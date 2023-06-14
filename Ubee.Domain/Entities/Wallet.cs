using Ubee.Domain.Commons;
using Ubee.Domain.Enums;

namespace Ubee.Domain.Entities;

public class Wallet : Auditable
{
    public string Name { get; set; }
    public decimal AvailableMoney { get; set; }
    public long CurrrencyId { get; set; }
    public Currency Currency { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
}
