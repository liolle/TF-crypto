using System.Text;
using BStorm.Tools.Encryptions.Cryptography.Symmetric;

namespace cryper.services;

public class Crypto(IConfiguration configuration)
{
    private readonly string _secret_key = configuration["SECRET_CRYPT_KEY"] ?? throw new Exception($"Missing configuration SECRET_CRYPT_KEY");

    public string Encrypt(string content, string crypt_key)
    {
        AesEncryption aesEncryption = new(Encoding.UTF8.GetBytes(_secret_key),Encoding.UTF8.GetBytes(crypt_key));
        return aesEncryption.Encrypt(content);
    }

    public string Decrypt(string encryptedContent,string crypt_key)
    {
        AesEncryption aesEncryption = new(Encoding.UTF8.GetBytes(_secret_key),Encoding.UTF8.GetBytes(crypt_key));
        return aesEncryption.Decrypt(encryptedContent);
    }
}