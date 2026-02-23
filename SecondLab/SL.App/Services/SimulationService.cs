using SL.Domain.Interfaces;
using SL.Domain.Entities;
using SL.Domain.Common;
using SL.App.Interfaces;
using SL.Domain.Validators;

namespace SL.App.Services;

public class SimulationService : ISimulationService
{
    private readonly IRepository<Teacher> _teacherRepo;
    private readonly IRepository<StudentGroup> _groupRepo;
    private readonly IRepository<Discipline> _disciplineRepo;
    private readonly IRepository<Equipment> _equipRepo;

    public SimulationService(IRepository<Teacher> teacherRepo, IRepository<StudentGroup> groupRepo, IRepository<Discipline> disciplineRepo, IRepository<Equipment> equipRepo)
    {
        _teacherRepo = teacherRepo;
        _groupRepo = groupRepo;
        _disciplineRepo = disciplineRepo;
        _equipRepo = equipRepo;
    }

    public void ConductLesson(Guid teacherId, Guid groupId, string disciplineName, string activityName)
    {
        var teacher = _teacherRepo.GetById(teacherId);
        var group = _groupRepo.GetById(groupId);
        var discipline = _disciplineRepo.GetAll().FirstOrDefault(d => d.Name == disciplineName);

        if (teacher is null)
            throw new KeyNotFoundException($"Teacher with Id {teacherId} not found");
        if (group is null)
            throw new KeyNotFoundException($"Group with Id {groupId} not found");
        if (discipline is null)
            throw new KeyNotFoundException($"Discipline '{disciplineName}' not found");

        var activity = discipline.Activities.FirstOrDefault(a => a.Name == activityName);

        if (activity is null)
            throw new KeyNotFoundException($"Activity '{activityName}' not found");

        var allEquipment = _equipRepo.GetAll().ToList();
        var equipmentToUse = StudyValidator.GetRequiredEquipmentOrThrow(discipline, allEquipment);

        StudyValidator.ValidateTeacher(teacher);
        StudyValidator.ValidateGroup(group, activity, discipline);

        try
        {
            foreach (var item in equipmentToUse)
            {
                item.SetBusy(true);
                _equipRepo.Update(item);
            }

            teacher.LessonFinished += group.OnLessonFinished;
            teacher.ConductLesson(discipline, activity);
            _groupRepo.Update(group);
        }
        finally
        {
            teacher.LessonFinished -= group.OnLessonFinished;

            foreach (var item in equipmentToUse)
            {
                item.SetBusy(false);
                _equipRepo.Update(item);
            }
        }
    }

    public int ConductExam(Guid groupId, string disciplineName)
    {
        var group = _groupRepo.GetById(groupId);
        var discipline = _disciplineRepo.GetAll().FirstOrDefault(d => d.Name == disciplineName);

        if (group is null)
            throw new KeyNotFoundException($"Group with Id {groupId} not found");
        if (discipline is null)
            throw new KeyNotFoundException($"Discipline '{disciplineName}' not found");

        var examActivity = discipline.Activities.FirstOrDefault(a => a.Name == "Exam");

        if (examActivity != null)
        {
            StudyValidator.ValidateGroup(group, examActivity, discipline);
            group.TakeExam(discipline.Name);
        }
        else
        {
            var creditActivity = discipline.Activities.FirstOrDefault(a => a.Name == "Credit");
            if (creditActivity != null)
            {
                StudyValidator.ValidateGroup(group, creditActivity, discipline);
                group.TakeCredit(discipline.Name);
            }
            else
            {
                throw new InvalidOperationException("No Exam or Credit found for this discipline.");
            }
        }

        _groupRepo.Update(group);

        StudyValidator.ValidateExamResult(group, discipline.Name, 60);

        return group.GradeBook[disciplineName];
    }
}