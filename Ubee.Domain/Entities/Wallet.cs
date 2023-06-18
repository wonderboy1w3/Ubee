using System.Text.Json.Serialization;
using Ubee.Domain.Commons;

namespace Ubee.Domain.Entities;

public class Wallet : Auditable
{
	public string Name { get; set; }
	public decimal AvailableMoney { get; set; }
	public long CurrrencyId { get; set; }
	public Currency Currency { get; set; }
	public long UserId { get; set; }
	public User User { get; set; }

	// EF Core Relationship
	[JsonIgnore]
	public ICollection<Info> Infos { get; set; }
	public ICollection<Transaction> Transactions { get; set; }
}
