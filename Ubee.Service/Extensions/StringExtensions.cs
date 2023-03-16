using System.Security.Cryptography;
using System.Text;

namespace Ubee.Service.Extensions;

public static class StringExtensions
{
    public static string Encrypt(this string password)
    {
        using var md5 = MD5.Create();
        var data = md5.ComputeHash(Encoding.UTF8.GetBytes(password));

        return Encoding.UTF8.GetString(data);
    }
}
