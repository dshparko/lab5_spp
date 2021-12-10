using System;
using System.Collections.Generic;
using System.Linq;

namespace DependencyInjectionContainerLib
{
    public class DependencyProvider
    {
        private DependenciesConfiguration Configuration { get; }

        public DependencyProvider(DependenciesConfiguration configuration)
        {
            try
            {
                ValidateConfiguration(configuration);
                Configuration = configuration;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }
        
        public TInterface Resolve<TInterface>()
            where TInterface : class
        {
            return (TInterface) Resolve(typeof(TInterface));
        }

        private static void ValidateConfiguration(DependenciesConfiguration configuration)
        {
            foreach (var implementations in configuration.Dependencies
                .SelectMany(
                    keyValuePair => keyValuePair.Value.Where(implementations => implementations.Type.IsAbstract)))
            {
                throw new Exception(implementations + " is abstract class");
            }
        }

        private object Resolve(Type interfaceType)
        {
            if (interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                var @interface = interfaceType.GetGenericArguments()[0];
                return ClassCreator.CreateClassIEnumerable(@interface, Configuration.Dependencies[@interface],
                    Configuration);
            }

            return ClassCreator.CreateClass(Configuration.Dependencies[interfaceType][0], Configuration);
        }
    }
}