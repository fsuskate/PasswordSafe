using System;
using System.Collections.Generic;
using System.Linq;

namespace PasswordSafeWeb.Database
{
    /// <summary>
    /// An in memory store that writes out to XML on exit
    /// </summary>
    public class PasswordStore : IDisposable
    {
        // TODO: Need to decouple this hard-dependency on XmlStorage
        private static readonly Lazy<PasswordStore> lazy = new Lazy<PasswordStore>(() => new PasswordStore(new XmlStorage()));
        private readonly List<UserInfo> _userInfos = new List<UserInfo>();
        private IStoreData _storeData;
        private long _nextId;
        private string _connectionString = "c:\\temp\\userinfo.xml";

        public static PasswordStore Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        private PasswordStore(IStoreData storeData)
        {
            _disposed = false;
            _storeData = storeData;
            _userInfos = _storeData.Load<List<UserInfo>>(_connectionString);
            if (_userInfos == null)
            {
                _userInfos = new List<UserInfo>();
                _nextId = 1000;
                return;
            }

            _nextId = _userInfos
                .FindLast(u => u != null)
                .Id;
        }

        ~PasswordStore()
        {
            Dispose(false);
        }

        private long GetNextId()
        {
            return ++_nextId;
        }

        public long Create(UserInfo userInfo)
        {
            if (userInfo.Id != -1)
            {
                throw new ArgumentException("New user must not have a user id!");
            }

            userInfo.Id = GetNextId();
            _userInfos.Add(userInfo);

            // Save all data out to file
            _storeData.Save<List<UserInfo>>(_userInfos, _connectionString);

            return userInfo.Id;
        }

        public bool Update(UserInfo userInfo)
        {
            var index = _userInfos.FindIndex(u => u.Id == userInfo.Id);
            if (index < 0)
            {
                throw new Exception("Could not find userinfo to update!");
            }

            _userInfos[index] = userInfo;

            // Save all data out to file
            _storeData.Save<List<UserInfo>>(_userInfos, _connectionString);

            return true;
        }

        public long Delete(UserInfo userInfo)
        {
            var index = _userInfos.FindIndex(u => u.Id == userInfo.Id);
            if (index < 0)
            {
                throw new Exception("Could not find userinfo to update!");
            }

            _userInfos.RemoveAt(index);

            // Save all data out to file
            _storeData.Save<List<UserInfo>>(_userInfos, _connectionString);

            return userInfo.Id;
        }

        public UserInfo Get(long id)
        {
            var userInfo = _userInfos.FirstOrDefault(u => u.Id == id);
            if (userInfo == null)
            {
                throw new Exception($"Could not find userinfo for id {id}");
            }

            return userInfo;
        }

        public List<UserInfo> GetAll()
        {
            return _userInfos;
        }

        private bool _disposed;
        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _disposed = true;
            }

            // Save all data out to file
            _storeData.Save<List<UserInfo>>(_userInfos, _connectionString);
        }
    }
}