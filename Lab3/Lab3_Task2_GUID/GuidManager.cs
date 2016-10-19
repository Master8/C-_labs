using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Task2_GUID
{
    class GuidManager
    {
        Dictionary<Type, Dictionary<Guid, object>> dictionary = new Dictionary<Type, Dictionary<Guid, object>>();

        public T Create<T>() where T : new()
        {
            T obj = new T();

            if (dictionary.ContainsKey(typeof(T)))
            {
                dictionary[typeof(T)].Add(Guid.NewGuid(), obj);
            }
            else
            {
                dictionary.Add(typeof(T), new Dictionary<Guid, object>() { { Guid.NewGuid(), obj } });
            }

            return obj;
        }

        public Dictionary<Guid, object> GetObjectsForType<T>()
        {
            if (dictionary.ContainsKey(typeof(T)))
                return dictionary[typeof(T)];
            else
                return null;
        }

        public T GetObject<T>(Guid guid)
        {
            if (dictionary.ContainsKey(typeof(T)))
            {
                var objects = dictionary[typeof(T)];

                if (objects.ContainsKey(guid))
                {
                    return (T)objects[guid];
                }
                else
                {
                    return default(T);
                }
            }
            else
            {
                return default(T);
            }
        }
    }
}
