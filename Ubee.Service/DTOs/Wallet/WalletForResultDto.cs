namespace Ubee.Service.DTOs.Wallet;

public class WalletForResultDto
{
    public string Name { get; set; }
    public decimal AvailableMoney { get; set; }
    public string Currency { get; set; }
    public long UserId { get; set; }
}
