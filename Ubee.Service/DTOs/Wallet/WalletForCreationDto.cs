namespace Ubee.Service.DTOs;

public class WalletForCreationDto
{
	public string Name { get; set; }
	public long UserId { get; set; }
	public long CurrrencyId { get; set; }
	public decimal AvailableMoney { get; set; }
}
