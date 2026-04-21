using System;
using Lab2.ChainOfResponsibility;
using Lab2.Command;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Select a behavioral pattern to demonstrate:");
                Console.WriteLine("1 - Chain of Responsibility");
                Console.WriteLine("2 - Command");
                Console.WriteLine("3 - Iterator");
                Console.WriteLine("4 - Mediator");
                Console.WriteLine("5 - Memento");
                Console.WriteLine("6 - Observer");
                Console.WriteLine("7 - State");
                Console.WriteLine("8 - Strategy");
                Console.WriteLine("9 - Template Method");
                Console.WriteLine("10 - Visitor");
                Console.WriteLine("0 - Exit");

                var input = Console.ReadLine();
                if (input == "0")
                {
                    break;
                }

                switch (input)
                {
                    case "1":
                        {
                            var request = new OrderRequest("A-1001", true, true);

                            IOrderHandler stock = new StockCheckHandler();
                            IOrderHandler payment = new PaymentCheckHandler();
                            IOrderHandler shipping = new ShippingHandler();

                            stock.SetNext(payment).SetNext(shipping);
                            stock.Handle(request);
                        }
                        break;
                    case "2":
                        {
                            var light = new Light();
                            var remote = new RemoteControl();

                            remote.SetCommand(new TurnOnCommand(light));
                            remote.PressButton();

                            remote.SetCommand(new TurnOffCommand(light));
                            remote.PressButton();
                        }
                        break;
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                    case "10":
                        Console.WriteLine("Folder renamed. Demo code for this pattern is not implemented yet.");
                        break;
                    default:
                        Console.WriteLine("Unknown option. Please choose 0..10.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}