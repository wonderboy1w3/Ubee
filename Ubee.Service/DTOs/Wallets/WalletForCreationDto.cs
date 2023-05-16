using System.ComponentModel.DataAnnotations;
using Ubee.Domain.Entities;

namespace Ubee.Service.DTOs.Wallets;

public class WalletForCreationDto
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    public string Currency { get; set; }
    public long UserId { get; set; }
}
