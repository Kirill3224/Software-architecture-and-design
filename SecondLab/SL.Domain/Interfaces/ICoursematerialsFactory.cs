using SL.Domain.Common;

namespace SL.Domain.Interfaces;

public interface ICourseMaterialsFactory
{
    IEquipment CreateEquipment();
    List<Activity> CreateActivities();
}