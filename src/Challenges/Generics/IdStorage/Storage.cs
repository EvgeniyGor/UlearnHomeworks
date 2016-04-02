using System;
using System.Collections.Generic;
using System.Linq;

namespace Generics.IdStorage
{
    public class Storage
    {
        private readonly Dictionary<Guid, Container> _storage;

        public Storage()
        {
            _storage = new Dictionary<Guid, Container>();
        }

        public T CreateObject<T>() where T: new()
        {
            var key = Guid.NewGuid();
            var container = new Container
            {
                Id = key,
                Object = new T(),
                Type = typeof (T)
            };
            _storage.Add(key, container);

            return (T)container.Object;
        }

        public IEnumerable<KeyValuePair<Guid, T>> GetObjects<T>()
        {
            return _storage
                .Where(i => i.Value.Type == typeof (T))
                .Select(i => new KeyValuePair<Guid, T>(i.Key, (T)i.Value.Object));
        }

        public T GetObject<T>(Guid key)
        {
            if (!_storage.ContainsKey(key))
            {
                return default(T);
            }

            return (T)_storage[key].Object;
        }
    }
}