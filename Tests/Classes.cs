using System;

namespace Tests
{

    interface IService
    {
        object GetTestFieldValue();
    }
    class ServiceImpl : IService
    {
        public IRepository Repository { get; }

        public ServiceImpl(IRepository repository)
        {
            Repository = repository;
        }

        public object GetTestFieldValue()
        {
            return Repository;
        }
    }
    class ServiceImpl1 : IService
    {
        private IRepository Repository;
        
        public ServiceImpl1(IRepository repository)
        {
            Repository = repository;
        }


        public object GetTestFieldValue()
        {
            return Repository;
        }
    }

    abstract class AbstractService : IService
    {
        public object GetTestFieldValue()
        {
            throw new Exception();
        }
    }

    public interface IRepository{}
    class RepositoryImpl : IRepository
    {
        private int g = 10;
        
        public RepositoryImpl()
        {
        }
    }
    class MySqlRepository : IRepository
    {
        public MySqlRepository()
        {
        }
    }
    
        interface ISomeInterface
            {
                void Firstmethod();

                void Secondmethod();
            }
        
            class Class : ISomeInterface
            {
        
                public void Firstmethod()
                {
                    throw new System.NotImplementedException();
                }
        
                public void Secondmethod()
                {
                    throw new System.NotImplementedException();
                }
            }
        
            interface ITestClass
            {
                void Firstmth();
        
                void Secondmth();
            }
        
            class TestClass : ITestClass
            {
                public ISomeInterface isomeInterface;
        
                public TestClass(ISomeInterface isomeInterface)
                {
                    this.isomeInterface = isomeInterface;
                }
        
                public void Firstmth()
                {
                    throw new System.NotImplementedException();
                }
        
                public void Secondmth()
                {
                    throw new System.NotImplementedException();
                }
            }
        
            class TestClass2 : ITestClass
            {
                public ISomeInterface isomeInterface;
        
                public TestClass2(ISomeInterface isomeInterface)
                {
                    this.isomeInterface = isomeInterface;
                }
        
                public void Firstmth()
                {
                    throw new System.NotImplementedException();
                }
        
                public void Secondmth()
                {
                    throw new System.NotImplementedException();
                }
            }
        
            class Class2 : ISomeInterface
            {
                public void Firstmethod()
                {
                    throw new System.NotImplementedException();
                }
        
                public void Secondmethod()
                {
                    throw new System.NotImplementedException();
                }
            }

            interface IB
            {
              void methodB();
            }

            class ClassB : IB
            {
                public void methodB()
                {
                    Console.WriteLine("method b");
                }
                public IA ia { get; set; }
                public ClassB(IA ia)
                {
                    this.ia = ia;
                    Console.WriteLine("B constructor: gets " + ia.ToString()+"\n");

                }
             
            }

            interface IA
            {
            
            }

            class ClassA : IA
            {
                public IB ib { get; set; }
                public ClassA(IB ib)
                {
                    this.ib = ib;
                }
              
            }
           interface IQ
           {
     
           }

           class Q : IQ
           {
               public IW iw { get; set; }
               public Q(IW iw)
               {
                   this.iw = iw;
               }

            
           }

           interface IW
           {
       
           }

           class W : IW
           {
               public IE ie { get; set; }
               public IQ iq { get; set; }
               public W(IE ie, IQ iq)
               {
                   this.ie = ie;
                   this.iq = iq;
               }
               
           }

           interface IE
           {
        
           }

           class E : IE
           {
               public IQ iq { get; set; }
               public E(IQ iq)
               {
                   this.iq = iq;
               }
               
           }

}