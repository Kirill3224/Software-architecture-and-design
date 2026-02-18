using SL.Domain.Common;
using SL.Domain.Entities;
using SL.Domain.Entities.Activities;
using SL.Domain.Interfaces;

namespace SL.Domain.Factory;

public class TechnicalCourseFactory : ICourseMaterialsFactory
{
    public List<IEquipment> CreateEquipment()
    {
        return new List<IEquipment>
        {
            new Computer()
        };
    }

    public List<Activity> CreateActivities()
    {
        return new List<Activity>
        {
            new Lecture(),
            new LabWork(),
            new TermPaper(),
            new ModularTests(),
            new Exam()
        };
    }
}