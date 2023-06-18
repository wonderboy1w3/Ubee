using System.Text.Json.Serialization;
using Ubee.Domain.Commons;

namespace Ubee.Domain.Entities;

public class Category : Auditable
{
    public string Name { get; set; }

    // EF Core Relationship
    [JsonIgnore]
    public ICollection<CategoryDetail> categoryDetails { get; set; }
}
