using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.API.Interfaces
{
    public interface IRedisService
    {
        void Set<T>(string key, T model);
        Task<bool> Clear();
        T Get<T>(string key);
        bool Contains(object key);
        void Remove(object key);
    }
}
