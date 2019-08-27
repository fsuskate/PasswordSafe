using System.Collections.Generic;

namespace PasswordSafeWeb.Services
{
    public interface IEncryptionService
    {
        string Encrypt(string input, Dictionary<string, string> parameters);

        string Decrypt(string input, Dictionary<string, string> parameters);
    }
}