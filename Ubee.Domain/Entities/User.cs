using System.Text.Json.Serialization;
using Ubee.Domain.Commons;

namespace Ubee.Domain.Entities;

public class User : Auditable
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Phone { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    // EF Core relationship
    [JsonIgnore]
    public ICollection<Wallet> Wallets { get; set; }
}
