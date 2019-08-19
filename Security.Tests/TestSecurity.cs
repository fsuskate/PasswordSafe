using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Security.Tests
{
    [TestClass]
    public class TestSecurity
    {
        [TestMethod]
        public void TestEncrypt()
        {
            var input = "Pa55w0rd";
            var output = Security.Encryption.Encrypt(input, 5);

            Assert.AreEqual("Uf::|5wi5", output);
        }

        [TestMethod]
        public void TestDecrypt()
        {
            var input = "Uf::|5wi5";
            var output = Security.Encryption.Decrypt(input);

            Assert.AreEqual("Pa55w0rd", output);
        }
    }
}
