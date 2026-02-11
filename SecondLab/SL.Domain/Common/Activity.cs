

namespace SL.Domain.Common;

public abstract class Activity
{
    public string Name { get; }
    public Activity(string name)
    {
        Name = name;
    }
}