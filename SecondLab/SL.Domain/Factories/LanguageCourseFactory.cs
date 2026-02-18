using SL.Domain.Common;
using SL.Domain.Entities;
using SL.Domain.Entities.Activities;
using SL.Domain.Interfaces;

namespace Sl.Domain.Factory;

public class LanguageCourseFactory : ICourseMaterialsFactory
{
    public List<IEquipment> CreateEquipment()
    {
        return new List<IEquipment>
        {
            new AudioSystem()
        };
    }

    public List<Activity> CreateActivities()
    {
        return new List<Activity>
        {
            new Practice(),
            new Test(),
            new Speaking(),
            new Reading(),
            new ModularTests(),
            new Credit()
        };
    }
}