using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace RU_NO_CRM_Functions.Services;

public class HashHelper
{
    public static string GenerateHashForString(string s)
    {
        return ComputeSha256Hash(s);
    }

    public static string? GenerateHashForJsonSerializableType<T>(T data)
    {
        if (data == null)
            return null;

        var json = JsonSerializer.Serialize(data);

        return ComputeSha256Hash(json);
    }

    private static string ComputeSha256Hash(string rawData)
    {
        // Create a SHA256   
        using SHA256 sha256Hash = SHA256.Create();
        // ComputeHash - returns byte array  
        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

        // Convert byte array to a string   
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < bytes.Length; i++)
        {
            builder.Append(bytes[i].ToString("x2"));
        }
        return builder.ToString();
    }
}