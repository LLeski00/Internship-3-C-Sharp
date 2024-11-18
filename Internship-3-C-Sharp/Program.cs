using ProjectManagerApp.Classes;
using ProjectManagerApp.Enums;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Task = ProjectManagerApp.Classes.Task;
using TaskStatus = ProjectManagerApp.Enums.TaskStatus;

namespace ProjectManagerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var projects = InstantiateProjects();
            var shutdown = false;

            do
            {
                ClearConsole();
                DisplayMainMenu();
                Console.WriteLine("Your choice: ");

                if (!int.TryParse(Console.ReadLine(), out var option)){
                    Console.WriteLine("Unfamiliar input!");
                    Console.ReadLine();
                    continue;
                }

                switch (option)
                {
                    case 0:
                        shutdown = true;
                        break;
                    case 1:
                        ClearConsole();
                        DisplayProjects(projects);
                        Console.ReadLine();
                        break;
                    case 2:
                        AddProject(projects);
                        break;
                    case 3:
                        DeleteProject(projects);
                        break;
                    case 4:
                        ClearConsole();
                        var dueTasks = new List<Task>();
                        var sevenDaysFromNow = DateTime.Now.AddDays(7);
                        foreach (var project in projects)
                        {
                            foreach(var task in project.Value)
                            {
                                if (task.GetDeadline() >= DateTime.Now && task.GetDeadline() <= sevenDaysFromNow)
                                    dueTasks.Add(task);
                            }
                        }
                        DisplayTasks(dueTasks);
                        Console.ReadLine();
                        break;
                    case 5:
                        var filteredProjects = FilterProjectsByStatus(projects);
                        ClearConsole();
                        DisplayProjects(filteredProjects);
                        Console.ReadLine();
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

        static void ClearConsole()
        {
            Console.Clear();
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine();
            }
            Console.SetCursorPosition(0, 0);
        }

        static Dictionary<Project, List<Task>> InstantiateProjects(){ 
            var projects = new Dictionary<Project, List<Task>>()
            {
                {
                    new Project("Project Titan", "A high-performance cloud infrastructure platform."),
                    new List<Task>()
                    {
                        new Task("Infrastructure Planning", "Design the architecture and infrastructure requirements for the cloud platform."),
                        new Task("Cloud Service Integration", "Integrate various cloud services (e.g., AWS, Azure) to enhance scalability and performance."),
                        new Task("Security Implementation", "Implement robust security protocols to safeguard sensitive data on the platform."),
                        new Task("Performance Optimization", "Analyze the cloud system’s performance and optimize it for high traffic and load."),
                        new Task("Client Onboarding", "Develop a user-friendly onboarding system for enterprise clients to easily migrate to the platform.")
                    }
                },
                {
                    new Project("Project Orion", "A space exploration program focusing on interplanetary communication."),
                    new List<Task>()
                    {
                        new Task("Communication Systems Design", "Design the communication systems for interplanetary transmission."),
                        new Task("Mars Rover Integration", "Develop and integrate communication modules for Mars rover operations."),
                        new Task("Satellite Deployment", "Deploy satellites to enhance signal strength and data transfer rates."),
                        new Task("Data Encryption for Space Communication", "Implement high-level encryption protocols to protect data during transmission."),
                        new Task("Research and Development", "Conduct research on new technologies that can improve communication between Earth and Mars.")
                    }
                },
                {
                    new Project("Project Phoenix", "Overhaul of a legacy software system with modern technologies."),
                    new List<Task>()
                    {
                        new Task("Code Refactoring", "Refactor the existing codebase to improve maintainability and performance."),
                        new Task("Database Migration", "Migrate the legacy database to a more efficient and scalable modern database system."),
                        new Task("User Interface Redesign", "Redesign the UI to enhance user experience and modernize the application."),
                        new Task("API Integration", "Integrate new external APIs to extend the system’s functionality."),
                        new Task("Testing & QA", "Conduct rigorous testing and quality assurance to ensure the system is stable and bug-free.")
                    }
                },
                {
                    new Project("Project Horizon", "Research and development of AI algorithms for self-driving vehicles."),
                    new List<Task>()
                    {
                        new Task("Sensor Calibration", "Calibrate and test sensors used in self-driving vehicles for optimal performance."),
                        new Task("Algorithm Development for Object Detection", "Develop machine learning algorithms to detect and identify objects on the road."),
                        new Task("Vehicle Control System", "Implement and test vehicle control systems for safe and smooth driving behavior."),
                        new Task("Navigation System Testing", "Test and validate the navigation system’s accuracy in different environments and conditions."),
                        new Task("Safety Protocols for Autonomous Vehicles", "Develop and integrate safety protocols to prevent accidents and improve decision-making in critical situations.")
                    }
                },
                {
                    new Project("Project Nova", "A mobile application for personal finance management."),
                    new List<Task>()
                    {
                        new Task("User Account Creation", "Implement a secure account creation and authentication system for app users."),
                        new Task("Budgeting Feature Development", "Develop a feature that allows users to create and manage personalized budgets."),
                        new Task("Spending Tracker", "Implement a system to track users’ spending habits across different categories."),
                        new Task("Financial Goal Setting", "Create a feature that helps users set and track financial goals (e.g., saving for a car, house)."),
                        new Task("Notifications and Reminders", "Develop a notification system that reminds users of bill payments, savings goals, and spending limits.")
                    }
                }
            };

            List<DateTime> deadlines = new List<DateTime>()
            {
                new DateTime(2025, 5, 10),
                new DateTime(2024, 8, 15),
                new DateTime(2024, 7, 20),
                new DateTime(2024, 11, 12),
                new DateTime(2025, 3, 5),
                new DateTime(2024, 6, 1),
                new DateTime(2025, 2, 25),
                new DateTime(2024, 9, 10),
                new DateTime(2025, 6, 17),
                new DateTime(2025, 8, 30),
                new DateTime(2024, 12, 5),
                new DateTime(2024, 7, 14),
                new DateTime(2024, 11, 22),
                new DateTime(2024, 9, 1),
                new DateTime(2025, 1, 18),
                new DateTime(2025, 3, 30),
                new DateTime(2024, 10, 10),
                new DateTime(2024, 12, 25),
                new DateTime(2024, 8, 22),
                new DateTime(2024, 11, 5),
                new DateTime(2025, 5, 20),
                new DateTime(2025, 4, 7),
                new DateTime(2024, 9, 30),
                new DateTime(2025, 6, 10),
                new DateTime(2024, 6, 15)
            };

            List<int> durations = new List<int>()
            {
                150, 90, 240, 180, 120, 90, 180, 150, 180, 120, 200, 90, 150, 120, 180, 150, 120, 180, 210, 240, 90, 60, 180, 150, 90
            };

            var deadlineId = 0;

            foreach (var project in projects.ToList())
            {
                var tasks = projects[project.Key];
                projects.Remove(project.Key);
                project.Key.SetStatus(new Random().Next(2) == 1 ? ProjectStatus.Active : ProjectStatus.OnHold);
                foreach (var task in tasks.ToList())
                {
                    tasks.Remove(task);
                    task.SetAssociatedProject(project.Key);
                    task.SetDeadline(deadlines[deadlineId]);
                    task.SetExpectedDurationInMinutes(durations[deadlineId++]);
                    if (task.GetDeadline() < DateTime.Now)
                        task.Status = new Random().Next(2) == 1 ? TaskStatus.Postponed : TaskStatus.Done;
                    tasks.Add(task);
                }
                projects.Add(project.Key, tasks);
            }

            return projects;
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

        static void DisplayProjects(Dictionary<Project, List<Task>> projects)
        {
            foreach (var project in projects)
            {
                Console.WriteLine($"{project.Key.Name}\n");
                Console.WriteLine($"{project.Key.Description}");
                Console.WriteLine($"Start date: {project.Key.GetStartDate()}");
                Console.WriteLine($"Status: {project.Key.GetStatus()}");
                Console.WriteLine("Tasks: ");
                DisplayTasks(project.Value);
            }
        }

        static void DisplayTasks(List<Task> tasks) {
            foreach (var task in tasks)
            {
                Console.WriteLine($"\t{task.Name}\n");
                Console.WriteLine($"\t{task.Description}");
                Console.WriteLine($"\tDeadline: {task.GetDeadline()}");
                Console.WriteLine($"\tStatus: {task.GetStatus()}");
                Console.WriteLine($"\tExpected duration: {task.ExpectedDurationInMinutes} min\n");
            }
        }

        static void AddProject(Dictionary<Project, List<Task>> projects)
        {
            var name = "Unknown";
            var description = "Unknown";

            do
            {
                ClearConsole();
                Console.WriteLine("Enter the name of the project: ");
                name = Console.ReadLine();

                if ( name == null  || name == string.Empty)
                {
                    Console.WriteLine("Name empty!");
                    Console.ReadLine();
                    continue;
                }

                Console.WriteLine("Enter the projects description: ");
                description = Console.ReadLine();

                if (description == null  || description == string.Empty)
                {
                    Console.WriteLine("Description empty!");
                    Console.ReadLine();
                    continue;
                }

                break;
            } while (true);

            var newProject = new Project(name, description);
            projects.Add(newProject, new List<Task>());

            Console.WriteLine("Project successfully added!");
            Console.ReadLine();
        }

        static void DeleteProject(Dictionary<Project, List<Task>> projects)
        {
            var projectToBeDeleted = new Project();
            var projectFound = false;

            do
            {
                ClearConsole();
                Console.WriteLine("Enter the name of the project you want to delete:");
                var name = Console.ReadLine();

                foreach (var project in projects)
                {
                    if (project.Key.Name == name)
                    {
                        projectFound = true;
                        projectToBeDeleted = project.Key;
                    }
                }

                if (!projectFound)
                {
                    Console.WriteLine("The project does not exist!");
                    Console.ReadLine();
                    continue;
                }

                Console.WriteLine("Are you sure you want to delete this project? (y/n)");
                var option = Console.ReadLine();

                if (option == null || option == string.Empty)
                {
                    Console.WriteLine("Incorrect input!");
                    Console.ReadLine();
                }
                else if (option.ToLower() == "y")
                {
                    projects.Remove(projectToBeDeleted);
                    Console.WriteLine("Project successfully deleted!");
                    Console.ReadLine();
                    break;
                }
                else if (option.ToLower() == "n")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Unfamiliar option!");
                    Console.ReadLine();
                }
            } while (!projectFound);
        }

        static Dictionary<Project, List<Task>> FilterProjectsByStatus(Dictionary<Project, List<Task>> projects)
        {
            var filteredProjects = new Dictionary<Project, List<Task>>();

            do
            {
                ClearConsole();
                Console.WriteLine("Filter projects with status of:");
                Console.WriteLine("1. Active");
                Console.WriteLine("2. On hold");
                Console.WriteLine("3. Done");
                Console.WriteLine("Your choice: ");
                if(!int.TryParse(Console.ReadLine(), out var option))
                {
                    Console.WriteLine("Incorrect input!");
                    Console.ReadLine();
                    continue;
                }

                switch (option)
                {
                    case 1:
                        foreach(var project in projects)
                        {
                            if (project.Key.GetStatus() == "Active")
                                filteredProjects[project.Key] = new List<Task>(project.Value);
                        }
                        break;
                    case 2:
                        foreach (var project in projects)
                        {
                            if (project.Key.GetStatus() == "On hold")
                                filteredProjects[project.Key] = new List<Task>(project.Value);
                        }
                        break;
                    case 3:
                        foreach (var project in projects)
                        {
                            if (project.Key.GetStatus() == "Done")
                                filteredProjects[project.Key] = new List<Task>(project.Value);
                        }
                        break;
                    default:
                        Console.WriteLine("Unfamiliar option!");
                        Console.ReadLine();
                        continue;
                }

                break;
            } while (true);

            return filteredProjects;
        }
    }
}