using System;
using Lab2.Adapter;
using Lab2.Bridge;
using Lab2.Composite;
using Lab2.Decorator;
using Lab2.Facade;
using Lab2.Proxy;
using Lab2.Flyweight;
namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true){
            Console.WriteLine("Select a pattern to demonstrate(/nAdapter- 1, Bridge-2, Composite-3, Decorator-4, Facade-5, Proxy-6, Flyweight-7, 0 - Exit):");
            var input = Console.ReadLine();
            if (input == "0") break;
            switch (input)
            {
                case "1":
                    {
                        var adapter = new LegacyLoggerAdapter(new LegacyLogger());
                        var service = new OrderService(adapter);
                        service.PlaceOrder("Laptop");
                    }
                    break;
                case "2":
                    {
                        Shape c = new Circle(new VectorRenderer(), 5);
                        c.Draw();   
                        c.Resize(2);
                        c.Draw();  
                        Shape s = new Square(new VectorRenderer(), 5);
                        s.Draw();  

                        Shape s1 = new Square(new RasterRenderer(), 4);
                        s1.Draw();
                        Shape c1 = new Circle(new RasterRenderer(), 4);
                        c1.Draw();
                    }
                    break;
                case "3":
                    {
                        var root = new Folder("root");
                        var src  = new Folder("src");

                        src.Add(new FiLe("Program.cs", 1200));
                        src.Add(new FiLe("Utils.cs",   800));
                        root.Add(src);
                        root.Add(new FiLe("README.md", 400));

                        root.Print();
                        Console.WriteLine($"Total: {root.GetSize()}B");
                    }
                    break;
                case "4":
                    {
                        IDataSource source = new FileDataSource();
                        source = new EncryptionDecorator(source);
                        source = new CompressionDecorator(source);

                        source.Write("Hello, World!");
                        var result = source.Read();
                        Console.WriteLine(result);
                    }
                    break;
                case "5":
                    {
                        var converter = new VideoConverter();
                        var output = converter.Convert("funny.ogg", "mp4");
                        Console.WriteLine($"Converted: {output}");
                    }
                    break;
                case "6":
                    {
                        var trees = new List<Tree>();
                        var rng   = new Random();

                        for (int i = 0; i < 1_000_00; i++)
                        {
                            var type = (i % 2 == 0)
                                ? TreeFactory.GetTreeType("Oak",  "green", "oak.png")
                                : TreeFactory.GetTreeType("Pine", "dark",  "pine.png");
                            trees.Add(new Tree(rng.Next(1000), rng.Next(1000), type));
                        }

                        Console.WriteLine($"Trees: {trees.Count}, TreeTypes: {TreeFactory.CacheSize()}");
                    }
                    break;
                case "7":
                    {
                        IImageLoader img = new LazyImageProxy("photo.jpg");
                        img.Display(); 
                        IImageLoader cached = new CachingImageProxy("photo.jpg");
                        cached.Display();
                        IImageLoader protectedImgAdmin = new ProtectedImageProxy("secret.png", "admin");
                        protectedImgAdmin.Display();
                        IImageLoader protectedImgUser = new ProtectedImageProxy("secret.png", "user");
                        protectedImgUser.Display();
                        IImageLoader logged = new LoggingImageProxy(
                            new LazyImageProxy("chart.png"));
                        logged.Display();
                    }
                    break;
            }
            }
        }
    }
}