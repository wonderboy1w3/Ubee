namespace Ubee.Service.DTOs.Wallet
{
    public class WalletForUpdateDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long UserId { get; set; }
        public string Currency { get; set; }
    }
}
