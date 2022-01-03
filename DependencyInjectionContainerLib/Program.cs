using System;
using System.Collections.Generic;
using System.Text;
using DependencyInjectionContainerLib;

namespace DependencyInjectionContainer
{
    class Program
    {
        public static void Main()
        {
            var config = new DependenciesConfiguration();
            config.Register<IA, A>(LifeCycle.Singleton);
            config.Register<IB, B>(LifeCycle.Singleton);

            var dp = new DependencyProvider(config);

            IA a = dp.Resolve<IA>();
        }
    }

    public interface IA
    {

    }
    public interface IB
    {

    }
    public interface IC
    {

    }

    public class A : IA
    {
        public IB b;
        public A(IB b)
        {
            this.b = b;
        }      
    }

    public class B :IB
    {
        public IA a;
        public IC c;

        public B(IA a, IC c)
        {
            this.a = a;
            this.c = c;
        }
    }

    public class C : IC
    {
        public IA a;
        public C(IA a)
        {
            this.a = a;
        }
    }
    
    public interface IQ
    {
     
    }

    public class Q : IQ
    {
        public IW iw { get; set; }
        public Q(IW iw)
        {
            this.iw = iw;
        }

            
    }

    public interface IW
    {
       
    }

    public class W : IW
    {
        public IE ie { get; set; }
        public IQ iq { get; set; }
        public W(IE ie, IQ iq)
        {
            this.ie = ie;
            this.iq = iq;
        }
               
    }

    public interface IE
    {
        
    }

    public class E : IE
    {
        public IQ iq { get; set; }
        public E(IQ iq)
        {
            this.iq = iq;
        }
               
    }
}