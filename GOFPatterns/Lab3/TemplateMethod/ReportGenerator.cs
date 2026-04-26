using System;

namespace Lab2.TemplateMethod
{
    public abstract class ReportGenerator
    {
        public void Generate()
        {
            var data = CollectData();
            var formatted = FormatData(data);
            Save(formatted);
        }

        protected abstract string CollectData();
        protected abstract string FormatData(string data);

        protected virtual void Save(string content)
        {
            Console.WriteLine(content);
        }
    }
}
