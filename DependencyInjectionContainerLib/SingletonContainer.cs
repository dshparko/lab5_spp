namespace DependencyInjectionContainerLib
{
    public class SingletonContainer
    {
        public readonly ImplNumber ImplNumber;

        public readonly object Instance;

        public SingletonContainer(object instance, ImplNumber number)
        {
            this.ImplNumber = number;
            this.Instance = instance;
        }
    }
}