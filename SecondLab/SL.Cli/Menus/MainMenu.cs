

namespace SL.App.Menus;

public class MainMenu
{
    public void Show()
    {
        Console.Title = "Stduy Simulation System";
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("1. Manage study gruops");
            Console.WriteLine("2. Manage teachers");
            Console.WriteLine("3. Start semester (Simulation)");
            Console.WriteLine("4. View the grade journal");
            Console.WriteLine("5. Check the equipment status");
            Console.WriteLine("0. Exit");
            Console.Write("\nSelect an option: ");
        }


    }
}