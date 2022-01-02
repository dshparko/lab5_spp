using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DependencyInjectionContainerLib
{
   public class ConfigValidator
    {
        private readonly Stack<Type> _locatedTypes;
        private readonly DependencyConfig _configuration;

        public ConfigValidator(DependencyConfig configuration)
        {
            this._configuration = configuration;
            this._locatedTypes = new Stack<Type>();
        }

        private bool IsInContainer(Type type)
        {
            return this._configuration.DependenciesDictionary.ContainsKey(type);
        }

        private bool CanBeCreated(Type instanceType)
        {
            this._locatedTypes.Push(instanceType);
            var constructors = instanceType.GetConstructors(BindingFlags.Instance | BindingFlags.Public);
            foreach (var constructor in constructors)
            {
                var requiredParams = constructor.GetParameters();
                foreach (var parameter in requiredParams)
                {
                    Type parameterType;
                    if (parameter.ParameterType.ContainsGenericParameters)
                    {
                        parameterType = parameter.ParameterType.GetInterfaces()[0];
                    }
                    else if (parameter.ParameterType.GetInterfaces().Any(i => i.Name == "IEnumerable"))
                    {
                        parameterType = parameter.ParameterType.GetGenericArguments()[0];
                    }
                    else
                    {
                        parameterType = parameter.ParameterType;
                    }

                    if (parameterType.IsInterface && IsInContainer(parameterType)) 
                        continue;
                    this._locatedTypes.Pop();
                    return false;
                }
            }

            this._locatedTypes.Pop();
            return true;
        }

        public bool Validate()
        {
            return this._configuration.DependenciesDictionary.Values.
                All(implementations => implementations.
                    All(implementation => CanBeCreated(implementation.ImplementationsType)));
        }
    }
}