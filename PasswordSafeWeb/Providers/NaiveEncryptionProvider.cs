using System;
using System.Collections.Generic;

namespace PasswordSafeWeb.Providers
{
    public class NaiveEncryptionProvider : IProvideEncryption
    {
        public string Decrypt(string input, Dictionary<string, string> parameters)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException(nameof(input));
            }

            return Security.NaiveEncryption.Decrypt(input);
        }

        public string Encrypt(string input, Dictionary<string, string> parameters)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException(nameof(input));
            }

            if (string.IsNullOrEmpty(parameters["rotateBy"]))
            {
                throw new ArgumentNullException("Missing parameter value");
            }

            int rotateBy = int.Parse(parameters["rotateBy"]);
            if (rotateBy < 0 || rotateBy > 9)
            {
                throw new ArgumentOutOfRangeException("Parameter must be between 1 and 10");
            }

            var output = Security.NaiveEncryption.Encrypt(input, rotateBy);
            return output;
        }
    }
}