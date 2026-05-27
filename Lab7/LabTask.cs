namespace Lab7;

public interface ILabTask
{
    string Name { get; }
    string Description { get; }
    void Run();
}
