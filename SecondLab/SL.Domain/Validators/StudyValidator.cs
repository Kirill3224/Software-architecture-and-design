using SL.Domain.Common;
using SL.Domain.Entities;

namespace SL.Domain.Validators;

public static class StudyValidator
{
    public static void ValidateGroup(StudentGroup group, Activity activity, Discipline discipline)
    {
        if (activity.IsRequireSplit && group.SubgroupSize < 10)
            throw new InvalidOperationException($"[Error] Subgroup size {group.SubgroupSize} is too small");

        if (activity.Name == "Exam" || activity.Name == "Modular Tests")
        {
            int subjectWorksCount = group.CompletedWorks.Count(w => w.StartsWith(discipline.Name));

            if (subjectWorksCount < 2)
            {
                throw new InvalidOperationException(
                    $"[Error] Group {group.Name} not admitted to {activity.Name}. " +
                    $"Submitted works for {discipline.Name}: {subjectWorksCount} (Need 2).");
            }
        }

        if (!discipline.CanBeStudiedBy(group))
            throw new InvalidOperationException($"[Error] Group {group.Name} cannot study {discipline.Name}");
    }

    public static void ValidateEquipment(Discipline discipline, List<Equipment> availableEquip)
    {
        var reservedIds = new HashSet<Guid>();

        foreach (var req in discipline.RequiredEquipment)
        {
            var freeItem = availableEquip.FirstOrDefault(e =>
                            e.GetType() == req.GetType() &&
                            !e.IsBusy &&
                            !reservedIds.Contains(e.Id)
                        );

            if (freeItem == null)
            {
                throw new InvalidOperationException($"[Error] Cannot start lesson. Missing required equipment: {req.Name} for discipline {discipline.Name}");
            }

            reservedIds.Add(freeItem.Id);
        }

    }

    public static void ValidateTeacher(Teacher teacher)
    {
        if (teacher.IsBusy)
            throw new InvalidOperationException($"[Error] {teacher.FirstName} is busy");
    }

    public static void ValidateExamResult(StudentGroup group, string disciplineName, int minScore = 60)
    {
        if (!group.GradeBook.TryGetValue(disciplineName, out int score))
        {
            throw new InvalidOperationException($"[Error] Group {group.Name} has not completed the exam on '{disciplineName}'.");
        }

        if (score < minScore)
        {
            throw new InvalidOperationException($"[Error] Group {group.Name} failed '{disciplineName}'. Current grade: {score}. Min grade: {minScore}.");
        }
    }
}