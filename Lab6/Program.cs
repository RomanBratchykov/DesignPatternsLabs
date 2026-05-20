using System;
using Microsoft.Extensions.DependencyInjection;

namespace Lab6
{
    public class DatabaseConnection
    {
        public void Connect() => Console.WriteLine(".");
    }

    public class RepositoryA { public RepositoryA(DatabaseConnection db) { } }
    public class RepositoryB { public RepositoryB(DatabaseConnection db) { } }
    public class RepositoryC { public RepositoryC(DatabaseConnection db) { } }
    public class RepositoryD { public RepositoryD(DatabaseConnection db) { } }
    public class RepositoryE { public RepositoryE(DatabaseConnection db) { } }
    public class RepositoryF { public RepositoryF(DatabaseConnection db) { } }

   public class ServiceA 
    { 
        public ServiceA(RepositoryA repoA, RepositoryB repoB) { } 
        public void DoWork() => Console.WriteLine("ServiceA працює.");
    }
    public class ServiceB 
    { 
        public ServiceB(RepositoryC repoC, RepositoryD repoD) { } 
        public void DoWork() => Console.WriteLine("ServiceB працює.");
    }
    public class ServiceC 
    { 
        public ServiceC(RepositoryE repoE, RepositoryF repoF) { } 
        public void DoWork() => Console.WriteLine("ServiceC працює.");
    }

    public class Application
    {
        private readonly ServiceA _serviceA;
        private readonly ServiceB _serviceB;
        private readonly ServiceC _serviceC;

        public Application(ServiceA serviceA, ServiceB serviceB, ServiceC serviceC)
        {
            _serviceA = serviceA;
            _serviceB = serviceB;
            _serviceC = serviceC;
        }

        public void Run()
        {
            Console.WriteLine("Додаток запущено (DI Контейнер побудовано успішно)!");
            _serviceA.DoWork();
            _serviceB.DoWork();
            _serviceC.DoWork();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<DatabaseConnection>();

            serviceCollection.AddTransient<RepositoryA>();
            serviceCollection.AddTransient<RepositoryB>();
            serviceCollection.AddTransient<RepositoryC>();
            serviceCollection.AddTransient<RepositoryD>();
            serviceCollection.AddTransient<RepositoryE>();
            serviceCollection.AddTransient<RepositoryF>();

            serviceCollection.AddTransient<ServiceA>();
            serviceCollection.AddTransient<ServiceB>();
            serviceCollection.AddTransient<ServiceC>();

            serviceCollection.AddTransient<Application>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var app = serviceProvider.GetService<Application>();

            app?.Run();
        }
    }
}
