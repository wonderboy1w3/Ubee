using System.ComponentModel.DataAnnotations;

namespace Ubee.Service.DTOs.Users;

public class UserForUpdateDto
{
	[Required]
	public long Id { get; set; }
	public string Phone { get; set; }
	[Required]
	public string Username { get; set; }
	public string Lastname { get; set; }
	public string Firstname { get; set; }
}
