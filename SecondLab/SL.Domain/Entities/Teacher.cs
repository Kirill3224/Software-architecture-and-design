using SL.Domain.Common;
using SL.Domain.Events;

namespace SL.Domain.Entities;

public class Teacher : BaseEntity
{
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public bool IsBusy { get; private set; } = false;

    public event EventHandler<LessonFinishedEventArgs>? LessonFinished;
    public event EventHandler<LessonStartedEventArgs>? LessonStarted;

    public Teacher(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    protected Teacher() { }

    public void ConductLesson(string disciplineName, Activity activity)
    {
        SetBusy(true);
        OnLessonStarted(new LessonStartedEventArgs(disciplineName, activity));

        SetBusy(false);
        OnLessonFinished(new LessonFinishedEventArgs(disciplineName, activity));
    }

    protected virtual void OnLessonFinished(LessonFinishedEventArgs e)
    {
        LessonFinished?.Invoke(this, e);
    }

    protected virtual void OnLessonStarted(LessonStartedEventArgs e)
    {
        LessonStarted?.Invoke(this, e);
    }

    public void SetBusy(bool newStatus)
    {
        IsBusy = newStatus;
    }
}