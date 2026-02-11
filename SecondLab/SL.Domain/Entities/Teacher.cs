using SL.Domain.Common;
using SL.Domain.Events;

namespace SL.Domain.Entities;

public class Teacher
{
    public string Name { get; }
    public bool IsBusy { get; private set; }

    public event EventHandler<LessonFinishedEventArgs>? LessonFinished;
    public event EventHandler<LessonStartedEventArgs>? LessonStarted;

    public Teacher(string name)
    {
        Name = name;
    }

    public void ConductLesson(string disciplineName, Activity activity)
    {
        IsBusy = true;
        OnLessonStarted(new LessonStartedEventArgs(disciplineName, activity));

        Thread.Sleep(1500);

        IsBusy = false;
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
}