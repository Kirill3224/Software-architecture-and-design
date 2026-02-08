

using FL.Domain.Entities;
using FL.Domain.Entities.Disciplines;
using FL.Domain.Interfaces;
using FL.Logic.Managers;

namespace Fl.App;

class Program
{
    static void Main()
    {
        var manager = new StudyProcessManager();
        var teacher1 = new Teacher("Dr. Smith");
        var group1 = new StudentGroup("IPZ-21", 1, 25);
        var equipment = new List<IEquipment> { new Computer() };

        group1.OnActivityCompleted += (msg) => System.Console.WriteLine($"[Nofification] {msg}");

        System.Console.WriteLine("- University simulation: ");

        var oop = new OOPDiscipline();
        manager.StartLesson(teacher1, group1, oop, oop.Activities[1], equipment);

        var english = new EnglishDiscipline();
        manager.StartLesson(teacher1, group1, oop, oop.Activities[0], equipment);

        var group2 = new StudentGroup("IPZ-12", 2, 22);
        manager.StartLesson(teacher1, group2, oop, oop.Activities[0], equipment);

        manager.StartLesson(teacher1, group1, oop, oop.Activities[3], equipment);

        System.Console.WriteLine("- End");
    }
}