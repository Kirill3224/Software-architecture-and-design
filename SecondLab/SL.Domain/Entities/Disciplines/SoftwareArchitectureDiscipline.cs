using SL.Domain.Entities.Activities;
using SL.Domain.Common;


namespace SL.Domain.Entities.Disciplines;

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