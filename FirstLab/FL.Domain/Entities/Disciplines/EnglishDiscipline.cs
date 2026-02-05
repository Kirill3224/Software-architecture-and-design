using FL.Domain.Entities.Activities;
using Fl.Domain.Entities;
using FL.Domain.Common;

namespace FL.Domain.Entities.Disciplines;

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