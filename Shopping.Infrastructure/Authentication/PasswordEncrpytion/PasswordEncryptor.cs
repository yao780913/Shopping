using Microsoft.Extensions.Options;
using Shopping.Domain.Common.Interfaces;

namespace Shopping.Infrastructure.Authentication.PasswordEncrpytion;

public class PasswordEncryptor: IPasswordEncryptor
{
    private readonly string _key;

    public PasswordEncryptor (IOptions<PasswordEncryptionSettings> options)
    {
        var passwordEncryptionSettings = options.Value;
        _key = passwordEncryptionSettings.Key;
    }
    
    public string Encrypt (string plainText)
    {
        //TODO:
        throw new NotImplementedException();
    }

    public string Decrypt (string cipherText)
    {
        //TODO:
        throw new NotImplementedException();
    }
}