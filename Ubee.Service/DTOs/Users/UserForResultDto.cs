using System.ComponentModel;
using Ubee.Domain.Entities;
using Ubee.Domain.Enums;

namespace Ubee.Service.DTOs.Users;

public class UserForResultDto
{
    public long Id { get; set; }

    [DisplayName("First Name")]
    public string FirstName { get; set; }

    [DisplayName("LastName")]
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public UserRole Role { get; set; } = UserRole.User;
}
