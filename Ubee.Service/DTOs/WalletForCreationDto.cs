using Ubee.Domain.Entities;

namespace Ubee.Service.DTOs;

public class WalletForCreationDto
{
    public string Name { get; set; }
    public string Currency { get; set; }
    public long UserId { get; set; }
}
