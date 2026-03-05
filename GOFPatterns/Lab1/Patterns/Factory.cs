using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1.Patterns
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
    public class GadgetFactory
    {
        public IGadget CreateGadget(string type)
        {
            switch (type.ToLower())
            {
                case "phone":
                    return new Phone();
                case "laptop":
                    return new Laptop();
                // case "watch":
                //     return new Watch();
                default:
                    throw new ArgumentException("Invalid gadget type");
            }
        }
    }
    public class Factory : IDemonstrate
    {
        public void Demonstrate()
        {
            Console.WriteLine("This is the Factory pattern demonstration.");
            GadgetFactory factory = new GadgetFactory();
            IGadget phone = factory.CreateGadget("phone");
            IGadget laptop = factory.CreateGadget("laptop");
            phone.Use();
            laptop.Use();
        }
    }
}