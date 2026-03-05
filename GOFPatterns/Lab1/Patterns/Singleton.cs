using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1.Patterns
{
    public class Singleton : IDemonstrate
    {
        public Singleton(){}

        public void Demonstrate()
        {
            DatabaseConnection db1 = DatabaseConnection.Instance;

            DatabaseConnection db2 = DatabaseConnection.Instance;

            if (ReferenceEquals(db1, db2))
            {
                Console.WriteLine("Success: Both variables contain the exact same instance, thus connection is shared.");
            }        }
    }
    public sealed class DatabaseConnection
    {
        private static readonly Lazy<DatabaseConnection> _instance = 
            new Lazy<DatabaseConnection>(() => new DatabaseConnection());
        // private static readonly SimpleSingleton _instance = new SimpleSingleton();
        // public static SimpleSingleton Instance
        // {
        //     get { return _instance; }
        // }
        private DatabaseConnection()
        {
            Console.WriteLine("Connecting to database");
        }

        public static DatabaseConnection Instance => _instance.Value;

        public void QueryData(string componentName)
        {
            Console.WriteLine($"      -> {componentName} is getting data from the shared Singleton connection.");
        }
    }
}