using SL.Domain.Common;

namespace SL.Domain.Interfaces;

public interface ICourseMaterialsFactory
{
    List<IEquipment> CreateEquipment();
    List<Activity> CreateActivities();
}