using FL.Domain.Entities;

namespace FL.Domain.Common;

public abstract class Discipline
{
    public string Name { get; } = string.Empty;
    public List<int> AllowedYears { get; }
    public List<Activity> Activities { get; } = new List<Activity>();
    public List<Type> RequiredEquipment { get; } = new List<Type>();

    public Discipline(string name, List<int> allowedYears)
    {
        Name = name;
        AllowedYears = allowedYears;
    }

    public virtual bool CanBeStudiedBy(StudentGroup group)
    {
        return AllowedYears.Contains(group.Year);
    }
}