using Ubee.Domain.Commons;

namespace Ubee.Domain.Entities;

public class Currency : Auditable
{
    public string Country { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Symbol { get; set; }
    public decimal Price { get; set; }
}
