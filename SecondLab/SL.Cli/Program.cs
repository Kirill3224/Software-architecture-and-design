using SL.App.Menus;
using SL.App.Services;
using SL.Cli.Managers;
using SL.Domain.Common;
using SL.Domain.Entities;
using SL.Infra.Repositories;

namespace SL.Cli;

class Program
{
    static void Main()
    {
        try
        {
            var groupRepo = new JsonRepository<StudentGroup>("groups.json");
            var teacherRepo = new JsonRepository<Teacher>("teachers.json");
            var disciplineRepo = new JsonRepository<Discipline>("disciplines.json");
            var equipmentRepo = new JsonRepository<Equipment>("equipments.json");

            var groupService = new GroupService(groupRepo);
            var teacherService = new TeacherService(teacherRepo);
            var simulationService = new SimulationService(teacherRepo, groupRepo, disciplineRepo, equipmentRepo);

            var groupManager = new GroupManager(groupService);
            var teacherManager = new TeacherManager(teacherService);

            var mainMenu = new MainMenu(groupManager, teacherManager);

            mainMenu.Show();
        }
        catch (Exception ex)
        {
            MinorMethods.ShowError($"Cannot launch program {ex.Message}");
        }
    }
}
