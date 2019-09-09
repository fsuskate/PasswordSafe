using System.Collections.Generic;
using System.Web.Http;
using PasswordSafeWeb.Services;

namespace PasswordSafeWeb.Controllers
{
    public class StorageController : ApiController
    {
        IStorageService _storageService;

        public StorageController(IStorageService storageService)
        {
            _storageService = storageService;
        }

        [HttpPost]
        [Route("Save")]
        public bool Save([FromBody]UserInfo value)
        {
            return _storageService.Save(value);
        }

        [HttpGet]
        [Route("Get")]
        public UserInfo Load(long id)
        {
            return _storageService.Load(id);
        }

        [HttpGet]
        [Route("GetAll")]
        public List<UserInfo> Load()
        {
            return _storageService.LoadAll();
        }
    }
}
