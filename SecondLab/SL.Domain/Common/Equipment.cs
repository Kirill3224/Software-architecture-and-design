

namespace SL.Domain.Common;

public abstract class Equipment : BaseEntity
{
    public string Name { get; }
    public bool IsBusy { get; private set; } = false;

    public Equipment(string name)
    {
        Name = name;
    }

    public void SetBusy(bool newStatus)
    {
        IsBusy = newStatus;
    }
}