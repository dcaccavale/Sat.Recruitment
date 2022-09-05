using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Service.Utils
{
    public static class ReflectionHelper
    {/// <summary>
     /// Create instance from type name string
     /// </summary>
     /// <typeparam name="T">Type class </typeparam>
     /// <param name="typeInstance"> string type class</param>
     /// <param name="args">An array of arguments that match in number, order, and type the parameters of
     ///     the constructor to invoke. If args is an empty array or null, the constructor
     ///     that takes no parameters (the parameterless constructor) is invoked.
     /// </param>
     /// <returns>Instance of T</returns>
     /// <exception cref="TypeLoadException">Invalid class type to instantiate</exception>
        public static T GetInstance<T>(string typeInstance, params object?[]? args) where T : class
        {
            Assembly? assembly;
            assembly = Assembly.GetAssembly(typeof(T));
            T? instance = null;
            if (assembly == null)
                throw new TypeLoadException("Invalid class type to instantiate");
            // Get the type contained in the name string
            Type? type = assembly.GetTypes().FirstOrDefault(t => t.Name == typeInstance);
            if (type != null)
            {
                // create an instance of that type
                instance = (T?)Activator.CreateInstance(type, args);

            }
            if (instance == null)
            {
                throw new TypeLoadException("Invalid class type to instantiate");
            }
            return instance;
        }

    }
}
