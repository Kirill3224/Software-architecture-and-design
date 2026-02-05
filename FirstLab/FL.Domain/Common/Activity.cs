

namespace FL.Domain.Common;

public abstract class Activity
{
    public string Name { get; set; } = string.Empty;
    public bool IsMandatoryForExam { get; set; }
    public Activity(string name, bool mandatory = true)
    {
        Name = name;
        IsMandatoryForExam = mandatory;
    }
}