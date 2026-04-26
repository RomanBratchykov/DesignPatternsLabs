namespace Lab2.TemplateMethod
{
    public class SalesReportGenerator : ReportGenerator
    {
        protected override string CollectData()
        {
            return "Sales: 3 orders, 195.00";
        }

        protected override string FormatData(string data)
        {
            return $"[SALES REPORT] {data}";
        }
    }
}
