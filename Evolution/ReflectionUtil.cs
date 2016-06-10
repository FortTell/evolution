using System;
using System.Collections.Generic;
using System.Linq;

namespace Evolution.Logic
{
    public static class ReflectionUtil
    {
        public static List<Type> GetTypesInheritedFrom(Type parentType)
        {
            var ass = System.Reflection.Assembly.GetEntryAssembly();
            return ass.GetTypes()
                .Where(t => t.BaseType == parentType)
                .ToList();
        }

        public static object CreateAtCoords(Type t, int x, int y)
        {
            var ctor = t.GetConstructor(new Type[] { typeof(int), typeof(int) });
            var obj = ctor.Invoke(new object[] { x, y });
            return obj;
        }
    }
}
