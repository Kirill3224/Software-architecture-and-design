

namespace FL.Domain.Entities;

public class StudentGroup
{
    public string Name { get; } = string.Empty;
    public int Year { get; }
    public int Size { get; }
    public int SubgroupSize { get; private set; }
    public List<string> CompletedWorks { get; } = new List<string>();

    public event Action<string>? OnActivityCompleted;

    public StudentGroup(string name, int year, int size)
    {
        Name = name;
        Year = year;
        Size = size;
        SubgroupSize = Size / 2;
    }

    public void CompleteActivity(string activityName)
    {
        CompletedWorks.Add(activityName);
        OnActivityCompleted?.Invoke($"{Name} completed: {activityName}");
    }
}