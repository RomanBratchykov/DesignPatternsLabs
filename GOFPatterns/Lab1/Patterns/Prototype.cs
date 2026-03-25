using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1.Patterns
{
    public class Proccesor
        {
            public string Model { get; set; } = string.Empty;
            public int Cores { get; set; }
        }
  
        //
        public interface IPhonePrototype
        {
            IPhonePrototype Clone();
        }

        public class PhonePrototype : IPhonePrototype
        {
            public int serialNum {get; set;}
            public int model {get; set;}

            public Proccesor Proccesor {get; set;}
            public IPhonePrototype Clone()
            {
                PhonePrototype clone = (PhonePrototype)this.MemberwiseClone();
                clone.Proccesor = new Proccesor

                
                { Model = this.Proccesor.Model, 
                Cores = this.Proccesor.Cores };
                return clone;
            }
            public void Display()
            {
                Console.WriteLine($"Phone with serial number: {serialNum}, model: {model}, Proccesor: {Proccesor.Model} with cores: {Proccesor.Cores}");
            }
        }
    public class Prototype : IDemonstrate
    {

        public void Demonstrate()
        {
            Console.WriteLine("This is the Prototype pattern demonstration.");
            PhonePrototype originalPhone = new PhonePrototype
            {
                serialNum = 12345,
                model = 1,
                Proccesor = new Proccesor { Model = "A14 Bionic", Cores = 6 }
            };
            PhonePrototype clonedPhone = (PhonePrototype)originalPhone.Clone();
            Console.WriteLine("Original phone:");
            originalPhone.Display();
            Console.WriteLine("Cloned phone:");
            clonedPhone.Display();    
        }
    }
}