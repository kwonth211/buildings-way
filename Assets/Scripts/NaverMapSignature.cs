using System;
using System.Security.Cryptography;
using System.Text;

public class NaverMapSignature
{
    public static string GenerateSignature(string clientSecret, string queryString)
    {
        using (HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(clientSecret)))
        {
            byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(queryString));
            return Convert.ToBase64String(hash);
        }
    }
}
