using System;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseViews.Test.Util
{
    public static class AssemblyUtil
    {
        public static List<Type> GetAllConstructableTypesOf<T>()
        {
            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(T).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).ToList();
            return types;
        }

        public static List<T> GetAllDefaultConstructableConstructed<T>()
        {
            var types = GetAllConstructableTypesOf<T>();

            List<T> result = new List<T>();
            foreach (var type in types)
            {
                result.Add((T)Activator.CreateInstance(type));
            }

            return result;
        }
    }
}