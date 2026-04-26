namespace Lab2.Visitor
{
    public interface IVisitable
    {
        void Accept(IVisitor visitor);
    }
}
