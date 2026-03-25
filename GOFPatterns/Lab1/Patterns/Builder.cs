using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1.Patterns
{ 
    public class Smartphone
    {
        public string CPU {get; set;} = string.Empty;
        public int RAM {get; set;}
        public int Storage {get; set;}
        public void Display()
        {
            Console.WriteLine($"Phone with CPU: {CPU}, RAM: {RAM}GB, Storage: {Storage}GB");
        }
    }
    public class Tablet
    {
        public string CPU {get; set;} = string.Empty;
        public int RAM {get; set;}
        public int Storage {get; set;}
        public void Display()
        {
            Console.WriteLine($"Tablet with CPU: {CPU}, RAM: {RAM}GB, Storage: {Storage}GB");
        }
        public Tablet(
            string cpu = "null", int ram = 10, int storage = 256
        ){} 
    }
    public class PhoneBuilder
    {
        private Smartphone _phone = new Smartphone();
        public PhoneBuilder SetCPU(string cpu)
        {
            _phone.CPU = cpu;
            return this;
        }
        public PhoneBuilder SetRAM(int ram)
        {
            _phone.RAM = ram;
            return this;
        }
        public PhoneBuilder SetStorage(int storage)
        {
            _phone.Storage = storage;
            return this;
        }
        public Smartphone Build()
        {
            return _phone;
        }
    }
    public class Builder : IDemonstrate
    {
        public void Demonstrate()
        {
            Tablet tablet = new Tablet(storage: 512, cpu: "Apple M1");

            Smartphone phone = new PhoneBuilder()
                .SetCPU("Snapdragon 888")
                .SetRAM(8)
                .SetStorage(128)
                .Build();
            phone.Display();
        }
    }
}