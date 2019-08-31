using System.Collections.Generic;
using System.Web.Http;
using PasswordSafeWeb.Services;

namespace PasswordSafeWeb.Controllers
{
    public class EncryptionController : ApiController
    {
        IEncryptionService _encryptionService;

        public EncryptionController(IEncryptionService encryptionService)
        {
            _encryptionService = encryptionService;
        }

        /// <summary>
        /// Default constructor is here until Dependency Injection is wired up.
        /// </summary>
        //public EncryptionController()
        //{
        //    _encryptionService = new EncryptionService();
        //}

        [HttpGet]
        [Route("Encrypt")]
        public string Encrypt(string input, int rotateBy)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("rotateBy", rotateBy.ToString());
            return _encryptionService.Encrypt(input, parameters);
        }

        [HttpGet]
        [Route("Decrypt")]
        public string Decrypt(string input)
        {
            return _encryptionService.Decrypt(input, null);
        }        
    }
}
