

using SL.Domain.Events;

namespace SL.Domain.Entities;

public class StudentGroup
{
    public string Name { get; }
    public int Year { get; }
    public int Size { get; }
    public int SubgroupSize { get; }
    public bool IsBusy { get; private set; } = false;
    public List<string> CompletedWorks { get; } = new List<string>();
    public Dictionary<string, int> GradeBook { get; } = new();

    public event EventHandler<LessonFinishedEventArgs>? JournalUpdated;

    public StudentGroup(string name, int year, int size)
    {
        Name = name;
        Year = year;
        Size = size;
        SubgroupSize = Size / 2;
    }

    public void OnLessonStarted(object? sender, LessonStartedEventArgs e)
    {
        SetBusy(true);
    }

    public void OnLessonFinished(object? sender, LessonFinishedEventArgs e)
    {

        CompletedWorks.Add($"{e.DisciplineName}: {e.CompletedActivity.Name}");

        SetBusy(false);

        OnJournalUpdated(e);
    }

    public virtual void OnJournalUpdated(LessonFinishedEventArgs e)
    {
        JournalUpdated?.Invoke(this, e);
    }

    public void SetBusy(bool newStatus)
    {
        IsBusy = newStatus;
    }

    public void TakeExam(string disciplineName)
    {
        int attendanceBonus = CompletedWorks.Count(w => w.StartsWith(disciplineName)) * 5;
        int luck = new Random().Next(0, 21);

        int totalScore = 50 + attendanceBonus + luck;
        if (totalScore > 100) totalScore = 100;

        if (GradeBook.ContainsKey(disciplineName))
            GradeBook[disciplineName] = totalScore;
        else
            GradeBook.Add(disciplineName, totalScore);
    }
}