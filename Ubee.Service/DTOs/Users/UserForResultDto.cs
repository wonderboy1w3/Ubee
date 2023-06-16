using Ubee.Domain.Entities;

namespace Ubee.Service.DTOs.Users;

public class UserForResultDto
{
    public long Id { get; set; }    
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Username { get; set; }
    public string Phone { get; set; }

}
