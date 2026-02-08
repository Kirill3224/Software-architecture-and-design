namespace FL.Domain.Entities;

public class Teacher
{
    public string Name { get; } = string.Empty;
    public bool IsBusy { get; private set; }

    public Teacher(string name)
    {
        Name = name;
    }

    public void SetBusy(bool busy)
    {
        IsBusy = busy;
    }
}