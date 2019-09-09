using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasswordSafeWeb.Services
{
    public interface IStorageService
    {
        bool Save(UserInfo obj);

        List<UserInfo> LoadAll();

        UserInfo Load(long id);
    }
}