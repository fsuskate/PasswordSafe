using System.Collections.Generic;

namespace PasswordSafeWeb.Providers
{
    public interface IProvideEncryption
    {
        string Encrypt(string input, Dictionary<string, string> parameters);

        string Decrypt(string input, Dictionary<string, string> parameters);
    }
}