using SL.Domain.Entities.Activities;
using SL.Domain.Common;


namespace SL.Domain.Entities.Disciplines;

public class OOPDiscipline : Discipline
{
    public OOPDiscipline() : base("OOP", new() { 1 })
    {
        Activities.Add(new Lecture());
        Activities.Add(new LabWork());
        Activities.Add(new ModularTests());
        Activities.Add(new TermPaper());
        Activities.Add(new Exam());
        Activities.Add(new Credit());
        RequiredEquipment.Add(typeof(Computer));
    }
}