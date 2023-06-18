using System.Text.Json.Serialization;
using Ubee.Domain.Commons;

namespace Ubee.Domain.Entities;

public class Currency : Auditable
{
    public string Country { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Symbol { get; set; }
    public decimal Price { get; set; }

    // EF Core Relationship
    [JsonIgnore]
    public ICollection<Wallet> Wallets { get; set; }
}
