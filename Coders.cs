

using System.Security.Cryptography;
using System.Text;
using System.Text.Unicode;

class Coders
{
    public static async Task<string> EncodeStringAsync(string text, string key)
    {
        using var aes = Aes.Create();
        aes.Key = UTF8Encoding.UTF8.GetBytes(key);
        aes.IV = new byte[16];
        ICryptoTransform enc = aes.CreateEncryptor(aes.Key, aes.IV);
        using var mes_stream = new MemoryStream();
        using var s = new StreamWriter(new CryptoStream(mes_stream, enc, CryptoStreamMode.Write));
        await s.WriteAsync(text);
        return Convert.ToBase64String(mes_stream.ToArray());
    }
    public static async Task<string> DecryptBytes(string enc_text, string key)
    {
        using var aes = Aes.Create();
        aes.Key = UTF8Encoding.UTF8.GetBytes(key);
        aes.IV = new byte[16];
        ICryptoTransform enc = aes.CreateEncryptor(aes.Key, aes.IV);
        using var mes_stream = new MemoryStream();
        using var s = new StreamReader(new CryptoStream(mes_stream, enc, CryptoStreamMode.Write));
        return await s.ReadToEndAsync();
    }
}