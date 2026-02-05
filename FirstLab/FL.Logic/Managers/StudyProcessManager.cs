using FL.Domain.Entities;
using FL.Domain.Common;
using FL.Domain.Interfaces;

namespace FL.Logic.Managers;

public class StudyProcessManager
{
    public void StartLesson(Teacher teacher, StudentGroup group, Discipline discipline, Activity activity, List<IEquipment> availableEquip)
    {
        if (teacher.IsBusy)
        {
            System.Console.WriteLine($"[Error] Teacher {teacher.Name} is Bussy"); return;
        }

        if (!discipline.CanBeStudiedBy(group))
        {
            System.Console.WriteLine($"[Error] Group {group.Name} cannot study {discipline.Name}"); return;
        }

        foreach (var req in discipline.RequiredEquipment)
        {
            if (!availableEquip.Any(e => e.GetType() == req))
            {
                System.Console.WriteLine($"[Error] Missing equipment: {req.Name} for {discipline.Name}"); return;
            }
        }

        if (activity.Name.Contains("Lab") && group.SubgroupSize < 10)
        {
            System.Console.WriteLine($"Subgroup size {group.SubgroupSize} is too small for Labs"); return;
        }

        if ((activity.Name == "Exam" || activity.Name == "Modular Tests") && group.CompletedWorks.Count < 2)
        {
            System.Console.WriteLine($"[Error] Group {group.Name} not admitted to {activity.Name} (works not submitted)."); return;
        }

        teacher.SetBusy(true);
        System.Console.WriteLine($"[Success] {teacher.Name} is conducting {activity.Name} for {group.Name}...");
        group.CompleteActivity(activity.Name);
        teacher.SetBusy(false);
    }
}