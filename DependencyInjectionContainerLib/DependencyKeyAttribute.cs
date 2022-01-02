using System;

namespace DependencyInjectionContainerLib
{
    //Задает элементы приложения, к которым допустимо применить атрибут
    [AttributeUsage(AttributeTargets.Parameter)]
    public class DependencyKeyAttribute : Attribute
    {
        public ImplNumber ImplNumber { get; }

        public DependencyKeyAttribute(ImplNumber number)
        {
            this.ImplNumber = number;
        }
    }
}