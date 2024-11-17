using ProjectManagerApp.Classes;
using System;
using Task = ProjectManagerApp.Classes.Task;

namespace ProjectManagerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var projects = new Dictionary<Project, List<Task>>();
            var shutdown = false;

            do
            {
                DisplayMainMenu();
                Console.WriteLine("Your choice: ");

                if (!int.TryParse(Console.ReadLine(), out var option)){
                    Console.WriteLine("Unfamiliar input!");
                    Console.ReadLine();
                }

                switch (option)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    default:
                        break;
                }

            } while (!shutdown);
        }

        static void DisplayMainMenu()
        {
            Console.WriteLine("\tPROJECT MANAGER\t");
            Console.WriteLine("1. Display all projects");
            Console.WriteLine("2. Add a new project");
            Console.WriteLine("3. Delete a project");
            Console.WriteLine("4. Show tasks with upcoming deadlines");
            Console.WriteLine("5. Display projects filtered by status");
            Console.WriteLine("6. Project management");
            Console.WriteLine("7. Task managemen");
            Console.WriteLine("0. Exit the app");
        }
    }
}