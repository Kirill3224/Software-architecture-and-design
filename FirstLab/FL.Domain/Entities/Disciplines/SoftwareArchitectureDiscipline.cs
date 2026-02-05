using FL.Domain.Entities.Activities;
using FL.Domain.Common;


namespace FL.Domain.Entities.Disciplines;

public class SoftwareArchitectureDiscipline : Discipline
{
    public SoftwareArchitectureDiscipline() : base("SA", new() { 2 })
    {
        Activities.Add(new Lecture());
        Activities.Add(new LabWork());
        Activities.Add(new ModularTests());
        Activities.Add(new TermPaper());
        Activities.Add(new Exam());
        RequiredEquipment.Add(typeof(Computer));
    }
}