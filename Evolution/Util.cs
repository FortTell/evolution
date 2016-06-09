using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution
{
    public static class Util
    {
        public static List<Type> GetTypesInheritedFrom(Type parentType)
        {
            var ass = System.Reflection.Assembly.GetEntryAssembly();
            return ass.GetTypes()
                .Where(t => t.BaseType == parentType)
                .ToList();
        }
    }
}
