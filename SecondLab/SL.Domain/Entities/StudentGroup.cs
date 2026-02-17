

using SL.Domain.Events;

namespace SL.Domain.Entities;

public class StudentGroup
{
    public string Name { get; }
    public int Year { get; }
    public int Size { get; }
    public int SubgroupSize { get; }
    public List<string> CompletedWorks { get; } = new List<string>();

    public event EventHandler<LessonFinishedEventArgs>? JournalUpdated;

    public StudentGroup(string name, int year, int size)
    {
        Name = name;
        Year = year;
        Size = size;
        SubgroupSize = Size / 2;

        if (SubgroupSize < 10)
            throw new ArgumentException("Group size is too small. Subgroup must have at least 10 students.");
    }

    public void OnLessonFinished(object sender, LessonFinishedEventArgs e)
    {

        CompletedWorks.Add($"{e.DisciplineName}: {e.CompletedActivity.Name}");

        OnJournalUpdated(e);
    }

    public virtual void OnJournalUpdated(LessonFinishedEventArgs e)
    {
        JournalUpdated?.Invoke(this, e);
    }
}