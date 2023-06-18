namespace Ubee.Service.DTOs.Wallet;

public class WalletForResultDto
{
	public long Id { get; set; }
    public string Name { get; set; }
    public long UserId { get; set; }
	public long CurrrencyId { get; set; }
	public decimal AvailableMoney { get; set; }
}
