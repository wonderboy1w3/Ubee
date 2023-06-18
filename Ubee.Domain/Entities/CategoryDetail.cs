using System.Text.Json.Serialization;
using Ubee.Domain.Commons;

namespace Ubee.Domain.Entities;

public class CategoryDetail : Auditable
{
    public long CategoryId { get; set; }
    public Category Category { get; set; }
    public string Name { get; set; }

    // EF Core Relationship
    [JsonIgnore]
    public ICollection<Transaction> Transactions { get; set; }
}