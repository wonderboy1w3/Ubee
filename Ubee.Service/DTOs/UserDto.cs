using Ubee.Domain.Entities;

namespace Ubee.Service.DTOs;

public class UserDto
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Username { get; set; }
    public string Phone { get; set; }

    public static explicit operator UserDto(User user)
    {
        return new UserDto
        {
            Firstname = user.Firstname,
            Lastname = user.Lastname,
            Phone = user.Phone,
            Username = user.Username,
        };
    }
}
