using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Flyweight
{
    public class TreeFactory
    {
        private static readonly Dictionary<string, TreeType> _cache = new();

        public static TreeType GetTreeType(
            string name, string color, string texture)
        {
            var key = $"{name}_{color}_{texture}";
            if (!_cache.ContainsKey(key))
            {
                Console.WriteLine($"Creating new TreeType: {key}");
                _cache[key] = new TreeType(name, color, texture);
            }
            return _cache[key];
        }

    public static int CacheSize() => _cache.Count;
    }
}