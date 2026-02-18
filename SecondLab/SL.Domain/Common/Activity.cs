

namespace SL.Domain.Common;

public abstract class Activity
{
    public string Name { get; }
    public bool IsRequireSplit { get; protected set; } = false;
    public Activity(string name)
    {
        Name = name;
    }
}