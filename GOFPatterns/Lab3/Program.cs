using System;
using Lab2.ChainOfResponsibility;
using Lab2.Command;
using Lab2.Iterator;
using Lab2.Mediator;
using Lab2.Memento;
using Lab2.Observer;
using Lab2.State;
using Lab2.Strategy;
using Lab2.TemplateMethod;
using Lab2.Visitor;

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
                        {
                            var catalog = new BookCollection();
                            catalog.Add(new Book("Design Patterns"));
                            catalog.Add(new Book("Clean Code"));
                            catalog.Add(new Book("Refactoring"));

                            var iterator = catalog.CreateIterator();
                            Console.WriteLine("Catalog:");
                            while (iterator.HasNext())
                            {
                                var book = iterator.Next();
                                Console.WriteLine($"- {book.Title}");
                            }
                        }
                        break;
                    case "4":
                            {
                                var room = new ChatRoom();
                                var alice = new ChatUser("Alice");
                                var bob = new ChatUser("Bob");
                                var carol = new ChatUser("Carol");

                                room.Register(alice);
                                room.Register(bob);
                                room.Register(carol);

                                alice.SendBroadcast("Hello everyone!");
                                bob.SendTo("Alice", "Hi Alice, welcome to the room.");
                                carol.SendTo("Bob", "I can see your message too.");
                            }
                            break;
                        case "5":
                            {
                                var editor = new TextEditor();
                                var history = new TextEditorHistory();

                                editor.Text = "Hello";
                                history.Save(editor);
                                Console.WriteLine($"Current text: {editor.Text}");

                                editor.Text = "Hello, world";
                                history.Save(editor);
                                Console.WriteLine($"Current text: {editor.Text}");

                                editor.Text = "Hello, world! This text will be undone.";
                                Console.WriteLine($"Current text: {editor.Text}");

                                history.Undo(editor);
                                Console.WriteLine($"After undo: {editor.Text}");

                                history.Undo(editor);
                                Console.WriteLine($"After second undo: {editor.Text}");
                            }
                        break;
                    case "6":
                        {
                            var subject = new OrderStatusSubject("A-1003");
                            subject.Attach(new CustomerObserver("Olena"));
                            subject.Attach(new WarehouseObserver());

                            subject.SetStatus("Paid");
                            subject.SetStatus("Shipped");
                        }
                        break;
                    case "7":
                        {
                            var order = new OrderContext("A-1002");

                            order.Next();
                            order.Next();
                            order.Next();
                            order.Next();
                        }
                        break;
                    case "8":
                        {
                            var orderTotal = 120m;
                            var calculator = new ShippingCostCalculator(new StandardShippingStrategy());

                            Console.WriteLine($"Order total: {orderTotal:C}");
                            Console.WriteLine($"{calculator.StrategyName} shipping: {calculator.Calculate(orderTotal):C}");

                            calculator.SetStrategy(new ExpressShippingStrategy());
                            Console.WriteLine($"{calculator.StrategyName} shipping: {calculator.Calculate(orderTotal):C}");
                        }
                        break;
                    case "9":
                        {
                            ReportGenerator sales = new SalesReportGenerator();
                            ReportGenerator inventory = new InventoryReportGenerator();

                            Console.WriteLine("Sales report:");
                            sales.Generate();

                            Console.WriteLine("Inventory report:");
                            inventory.Generate();
                        }
                        break;
                    case "10":
                        {
                            IVisitable[] items =
                            {
                                new OrderItem("Keyboard", 50m),
                                new OrderItem("Mouse", 25m),
                                new ShippingItem("Standard", 10m)
                            };

                            var priceVisitor = new PriceVisitor();
                            foreach (var item in items)
                            {
                                item.Accept(priceVisitor);
                            }

                            Console.WriteLine($"Total: {priceVisitor.Total:C}");

                            var descriptionVisitor = new DescriptionVisitor();
                            foreach (var item in items)
                            {
                                item.Accept(descriptionVisitor);
                            }
                        }
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