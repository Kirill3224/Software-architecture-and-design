

using SL.Cli;
using SL.Cli.Managers;

namespace SL.App.Menus;

public class MainMenu
{
    private readonly GroupManager _groupManager;
    private readonly TeacherManager _teacherManager;

    public MainMenu(GroupManager groupManager, TeacherManager teacherManager)
    {
        _groupManager = groupManager;
        _teacherManager = teacherManager;
    }
    public void Show()
    {
        Console.Title = "Stduy Simulation System";

        while (true)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"--- Stduy Simulation System ---");
            Console.ResetColor();

            Console.WriteLine("1. Manage study gruops");
            Console.WriteLine("2. Manage teachers");
            Console.WriteLine("3. Start semester (Simulation)");
            Console.WriteLine("4. View the grade journal");
            Console.WriteLine("5. Check the equipment status");
            Console.WriteLine("0. Exit");
            Console.Write("\nSelect an option: ");

            string choice = Console.ReadLine() ?? string.Empty;

            if (choice == "0") break;

            switch (choice)
            {
                case "1": _groupManager.Run(); break;
                case "2": _teacherManager.Run(); break;
                default:
                    MinorMethods.ShowError("Invalid option. Try again.");
                    break;
            }
        }


    }
}