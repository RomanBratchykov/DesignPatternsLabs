namespace Lab2.TemplateMethod
{
    public class InventoryReportGenerator : ReportGenerator
    {
        protected override string CollectData()
        {
            return "Stock: 12 items, 2 low";
        }

        protected override string FormatData(string data)
        {
            return $"[INVENTORY REPORT] {data}";
        }
    }
}
