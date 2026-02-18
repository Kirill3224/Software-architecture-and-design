using SL.Domain.Entities.Activities;
using SL.Domain.Entities;
using SL.Domain.Common;

namespace SL.Domain.Entities.Disciplines;

public class EnglishDiscipline : Discipline
{
    public EnglishDiscipline() : base("English", new() { 1, 2 })
    {
        throw new NotImplementedException();
    }
}