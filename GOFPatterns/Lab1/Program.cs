using System;
using System.Collections.Generic;
using System.Linq;
using Lab1.Patterns;

public class Program
{
    public static void Main(string[] args)
    {
        while (true){
        Console.WriteLine("Enter name of pattern to demonstrate, exit to leave:");
            var patternName = Console.ReadLine();
            if (patternName.ToLower() == "exit"){
                return 0;
            }
            if (string.IsNullOrWhiteSpace(patternName))
            {
                Console.WriteLine("Pattern name cannot be empty.");
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                return;
            }
            var patternTypes = typeof(AbstractFactory).Assembly.GetTypes()
            .Where(t => t.IsClass && t.Namespace == "Lab1.Patterns" && t.Name.ToLower() == patternName.ToLower())
            .ToList();
        if (patternTypes.Count == 0)
        {
            Console.WriteLine("Pattern not found.");
            return;
        }
        var patternType = patternTypes.First();
        Console.WriteLine($"Demonstrating {patternType.Name} pattern:");
        var patternInstance = Activator.CreateInstance(patternType);
        var methodInfo = patternType.GetMethod("Demonstrate");
        if (methodInfo == null)
        {
            Console.WriteLine("Demonstrate method not found in pattern class.");
            return;
        }
        methodInfo.Invoke(patternInstance, null);
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
    }
}