using PasswordSafeWeb.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PasswordSafeWeb.Services
{
    public class StorageService : IStorageService
    {
        public StorageService()
        {
        }

        public UserInfo Load(long id)
        {
            return PasswordStore.Instance.Get(id);            
        }

        public List<UserInfo> LoadAll()
        {
            return PasswordStore.Instance.GetAll();
        }

        public bool Save(UserInfo obj)
        {
            if (obj.Id != -1)
            {
                return PasswordStore.Instance.Update(obj);
            }

            return (PasswordStore.Instance.Create(obj) != -1);
           
        }
    }
}