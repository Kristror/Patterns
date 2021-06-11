using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Asteroids.Serialization {
    sealed class DictionarySerializationSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(Object obj,
        SerializationInfo info, StreamingContext context)
        {
            var dictionary = (Dictionary<string, string>)obj;
            foreach(var pair in dictionary)
            {
                info.AddValue("Key", pair.Key);
                info.AddValue("Value", pair.Value);
            }
        }
        public Object SetObjectData(Object obj,
            SerializationInfo info, StreamingContext context,
            ISurrogateSelector selector)
        {

            var dictionary = (Dictionary<string, string>)obj;
            dictionary.Add(info.GetString("Key"), info.GetString("Value"));
            return dictionary;
        }
    }
}
