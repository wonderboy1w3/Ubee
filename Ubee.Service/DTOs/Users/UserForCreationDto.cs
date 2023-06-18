using System.ComponentModel.DataAnnotations;

namespace Ubee.Service.DTOs.Users;

public class UserForCreationDto
{
	public string Phone { get; set; }

	[Required]
	public string Username { get; set; }

	public string Lastname { get; set; }

	[Required]
	public string Password { get; set; }

	public string Firstname { get; set; }

}
