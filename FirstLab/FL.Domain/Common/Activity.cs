

namespace FL.Domain.Common;

public abstract class Activity
{
    public string Name { get; } = string.Empty;
    public Activity(string name)
    {
        Name = name;
    }
}