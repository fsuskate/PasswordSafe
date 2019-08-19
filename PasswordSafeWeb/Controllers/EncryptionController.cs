using System.Collections.Generic;
using System.Web.Http;

namespace PasswordSafeWeb.Controllers
{
    public class EncryptionController : ApiController
    {
        [HttpGet]
        [Route("Encrypt")]
        public string Encrypt(string input, int rotateBy)
        {
            var output = Security.Encryption.Encrypt(input, rotateBy);
            return output;
        }

        [HttpGet]
        [Route("Decrypt")]
        public string Decrypt(string input)
        {
            return Security.Encryption.Decrypt(input);
        }        
    }
}
