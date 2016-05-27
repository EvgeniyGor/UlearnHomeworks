using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Generics.IdStorage
{
    public class Storage
    {
        private struct Container
        {
            public object Object { get; set; }
            public Type Type { get; set; }
        }

        private readonly ConcurrentDictionary<Guid, Container> _storageById;
        private readonly ConcurrentDictionary<Type, List<Container>> _storageByType; 

        public Storage()
        {
            _storageById = new ConcurrentDictionary<Guid, Container>();
     //       _storageByType = new ConcurrentDictionary<Type, Container>();
        }

        public T CreateObject<T>() where T: new()
        {
            var key = Guid.NewGuid();
            var obj = new T();
            var container = new Container
            {
                Object = obj,
                Type = typeof (T)
            };
            //TODO: сделать concurrentDictionary
         //   _storageById.AddOrUpdate(container);

            return obj;
        }

        //TODO: сделать быстро через второй дикшенри
        public IEnumerable<KeyValuePair<Guid, T>> GetObjects<T>()
        {
            //var 
            //return _storageByType.TryGetValue()

            return _storageById
                .Where(i => i.Value.Type == typeof (T))
                .Select(i => new KeyValuePair<Guid, T>(i.Key, (T)i.Value.Object));
        }

        public T GetObject<T>(Guid key)
        {
            if (!_storageById.ContainsKey(key))
            {
                return default(T);
            }

            return (T)_storageById[key].Object;
        }
    }
}