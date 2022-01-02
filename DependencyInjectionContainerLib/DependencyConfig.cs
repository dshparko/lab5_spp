using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DependencyInjectionContainerLib
{
    public class DependencyConfig
    {
        public Dictionary<Type, List<ImplContainer>> DependenciesDictionary { get; private set; }

        public DependencyConfig()
        {
            DependenciesDictionary = new Dictionary<Type, List<ImplContainer>>();
        }

        public void Register<TDependency, TImplementation>(LifeCycle ttl = LifeCycle.InstancePerDependency,ImplNumber number = ImplNumber.None) 
            where TDependency : class 
            where TImplementation : TDependency
        {
            Register(typeof(TDependency), typeof(TImplementation), ttl, number);
        }

        public void Register(Type interfaceType, Type implementType, LifeCycle ttl, ImplNumber number)
        {
            if (!IsDependency(implementType, interfaceType))
            {
                throw new ArgumentException("Incompatible parameters");
            }

            var implContainer = new ImplContainer(implementType, ttl, number);
            if (this.DependenciesDictionary.ContainsKey(interfaceType))
            {
                var index = this.DependenciesDictionary[interfaceType]
                    .FindIndex(value => value.ImplementationsType == implContainer.ImplementationsType);
                if (index != -1)
                {
                    this.DependenciesDictionary[interfaceType].RemoveAt(index);
                }

                this.DependenciesDictionary[interfaceType].Add(implContainer);

            }
            else
            {
                this.DependenciesDictionary.Add(interfaceType, new List<ImplContainer>() { implContainer });
            }
        }

        private bool IsDependency(Type implementation, Type dependency)
        {
            return implementation.IsAssignableFrom(dependency) 
                   || implementation.GetInterfaces().Any(i => i.ToString() == dependency.ToString());
        }
    }
}