using PasswordSafeWeb.Providers;
using System;
using System.Collections.Generic;

namespace PasswordSafeWeb.Services
{
    public class EncryptionService : IEncryptionService
    {
        private IProvideEncryption _encrytionProvider;

        public EncryptionService(IProvideEncryption provider)
        {
            _encrytionProvider = provider;
        }

        /// <summary>
        /// Default constructor until DI is wired up
        /// </summary>
        public EncryptionService()
        {
            _encrytionProvider = new NaiveEncryptionProvider();
        }

        public string Encrypt(string input, Dictionary<string, string> parameters)
        {
            return _encrytionProvider.Encrypt(input, parameters);
        }

        public string Decrypt(string input, Dictionary<string, string> parameters)
        {
            return _encrytionProvider.Decrypt(input, parameters);
        }
    }
}