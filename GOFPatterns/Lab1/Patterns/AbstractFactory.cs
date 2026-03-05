using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1.Patterns
{
    public interface IButton
    {
        void Render();
    }
    //
    public interface ICheckbox
    {
        void Render();
    }
    //
    public class WindowsButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Rendering a Windows button.");
        }
    } 
    //
    public class WindowsCheckboc : ICheckbox
    {
        public void Render()
        {
            Console.WriteLine("Rendering a Windows checkbox.");
        }
    }
    //
    public class MacButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Rendering a Mac button.");
        }
    } 
    //
    public class MacCheckbox : ICheckbox
    {
        public void Render()
        {
            Console.WriteLine("Rendering a Mac checkbox.");
        }
    }
    //
    public interface IGUIFactory
    {
        IButton CreateButton();
        ICheckbox CreateCheckbox();
    }
    public class WindowsFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new WindowsButton();
        }
        public ICheckbox CreateCheckbox()
        {
            return new WindowsCheckboc();
        }
    }
    //
    public class MacFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new MacButton();
        }
        public ICheckbox CreateCheckbox()
        {
            return new MacCheckbox();
        }
    }
    //
    public class Application
    {
        private IButton _button;
        private ICheckbox _checkbox;
        public Application(IGUIFactory factory)
        {
            _button = factory.CreateButton();
            _checkbox = factory.CreateCheckbox();
        }
        public void Render()
        {
            _button.Render();
            _checkbox.Render();
        }
    }
    public class AbstractFactory : IDemonstrate
    {
        public void Demonstrate()
        {
            Console.WriteLine("This is the Abstract Factory pattern demonstration.");
            IGUIFactory winGUI = new WindowsFactory();
            Application winApp = new Application(winGUI);
            winApp.Render();
            IGUIFactory macGUI = new MacFactory();
            Application macApp = new Application(macGUI);
            macApp.Render();
        }
    }
}