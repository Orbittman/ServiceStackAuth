using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceStackAuth.Caching
{
    using ServiceStack.CacheAccess;

    public class DictionaryCache
        : ICacheClient
    {
        private Dictionary<string, object> _container = new Dictionary<string, object>();

        public void Dispose()
        {
            
        }

        public bool Remove(string key)
        {
            return _container.Remove(key);
        }

        public void RemoveAll(IEnumerable<string> keys)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(string key)
        {
            return _container.ContainsKey(key) ? (T)_container[key] : default(T);
        }

        public long Increment(string key, uint amount)
        {
            throw new NotImplementedException();
        }

        public long Decrement(string key, uint amount)
        {
            throw new NotImplementedException();
        }

        public bool Add<T>(string key, T value)
        {
            _container.Add(key, value);

            return true;
        }

        public bool Set<T>(string key, T value)
        {
            if (_container.ContainsKey(key))
            {
                _container[key] = value;
            }
            else
            {
                _container.Add(key, value);
            }

            return true;
        }

        public bool Replace<T>(string key, T value)
        {
            if (_container.ContainsKey(key))
            {
                _container[key] = value;
                return true;
            }

            return false;
        }

        public bool Add<T>(string key, T value, DateTime expiresAt)
        {
            throw new NotImplementedException();
        }

        public bool Set<T>(string key, T value, DateTime expiresAt)
        {
            throw new NotImplementedException();
        }

        public bool Replace<T>(string key, T value, DateTime expiresAt)
        {
            throw new NotImplementedException();
        }

        public bool Add<T>(string key, T value, TimeSpan expiresIn)
        {
            throw new NotImplementedException();
        }

        public bool Set<T>(string key, T value, TimeSpan expiresIn)
        {
            throw new NotImplementedException();
        }

        public bool Replace<T>(string key, T value, TimeSpan expiresIn)
        {
            throw new NotImplementedException();
        }

        public void FlushAll()
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, T> GetAll<T>(IEnumerable<string> keys)
        {
            throw new NotImplementedException();
        }

        public void SetAll<T>(IDictionary<string, T> values)
        {
            throw new NotImplementedException();
        }
    }
}