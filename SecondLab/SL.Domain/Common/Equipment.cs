

namespace SL.Domain.Common;

public abstract class Equipment
{
    public string Name { get; }
    public bool IsTaken { get; private set; } = false;

    public Equipment(string name)
    {
        Name = name;
    }

    public void SetTaken(bool newStatus)
    {
        IsTaken = newStatus;
    }
}