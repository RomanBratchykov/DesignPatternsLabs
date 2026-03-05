using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1.Patterns
{
    public class FactoryMethod : IDemonstrate
    {
         public interface IGadget
    {
        void Use();
    }
    public class Phone : IGadget
    {
        public void Use()
        {
            Console.WriteLine("Using a phone.");
        }
    }
    public class Laptop : IGadget
    {
        public void Use()
        {
            Console.WriteLine("Using a laptop.");
        }
    }
    // public class Watch : IGadget
    // {
    //     public void Use()
    //     {
    //         Console.WriteLine("Using a watch.");
    //     }
    // }
    public abstract class GadgetFactory
        {
            public abstract IGadget CreateGadget();
            public void UseGadget()
            {
                IGadget gadget = CreateGadget();
                gadget.Use();
            }
        }
    public class PhoneFactory : GadgetFactory
        {
            public override IGadget CreateGadget()
            {
                Console.WriteLine("Creating a phone...");
                return new Phone();
            }
        }
    public class LaptopFactory : GadgetFactory
        {
            public override IGadget CreateGadget()
            {
                Console.WriteLine("Creating a laptop...");
                return new Laptop();
            }
        }
    // public class WatchFactory : GadgetFactory
    //     {
    //         public override IGadget CreateGadget()
    //         {
    //             Console.WriteLine("Creating a watch...");
    //             return new Watch();
                
    //         }
    //     }
        public void Demonstrate()
        {
            Console.WriteLine("This is the Factory Method pattern demonstration.");
            GadgetFactory phoneFactory = new PhoneFactory();
            phoneFactory.UseGadget();
            GadgetFactory laptopFactory = new LaptopFactory();
            laptopFactory.UseGadget();
        }
    }
}