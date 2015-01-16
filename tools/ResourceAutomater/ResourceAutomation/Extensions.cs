using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace ResourceAutomation
{
    public static class Extensions
    {
        public static void AddOnlyNewItens<T>(this List<T> list, List<T> otherList, Func<IEnumerable<T>, IEnumerable<T>> customTransform)
        {
            list.AddRange(customTransform(otherList.Except(list)));
        }
        public static T Deserialize<T>(this XmlSerializer serializer, string path)
        {
            T root;
            using (var stream = File.OpenRead(path))
                root = (T)serializer.Deserialize(stream);
            return root;
        }
        public static void Serialize<T>(this XmlSerializer serializer, T obj, string path, FileMode fileMode = FileMode.Create)
        {
            using (var stream = File.Open(path, fileMode))
                serializer.Serialize(stream, obj);
        }
    }
}