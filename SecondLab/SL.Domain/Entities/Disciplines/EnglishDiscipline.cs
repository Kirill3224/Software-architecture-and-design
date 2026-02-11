using SL.Domain.Entities.Activities;
using SL.Domain.Entities;
using SL.Domain.Common;

namespace SL.Domain.Entities.Disciplines;

public class EnglishDiscipline : Discipline
{
    public EnglishDiscipline() : base("English", new() { 1, 2 })
    {
        Activities.Add(new Practice());
        Activities.Add(new Test());
        Activities.Add(new Speaking());
        Activities.Add(new Reading());
        Activities.Add(new ModularTests());
        Activities.Add(new Credit());
        RequiredEquipment.Add(typeof(Computer));
        RequiredEquipment.Add(typeof(AudioSystem));
    }
}