using System;

namespace Homework8;

public class Teamlead : Employee
{
    internal List<Worker> team;
    public Teamlead(string name) : base(name)
    {
        team = new List<Worker>();
    }

    public void AddWorkerToTeam(Worker worker)
    {
        team.Add(worker);
    }

    public void CreateTask(Project project, string description, int daysToComplete, Customer initiator)
    {
        if (project.status != ProjectStatus.Project)
        {
            Console.WriteLine("Ошибка: Задачи можно создавать только в проекте со статусом 'Проект'.");
            return;
        }

        var task = new Task(description, daysToComplete, initiator);
        project.tasks.Add(task);
    }
    public void CreateTask(Project project, string description, int daysToComplete, Customer initiator, bool isPeriodic = false, TimeSpan? reportingInterval = null, int reportCount = 1)
    {
        if (project.status != ProjectStatus.Project)
        {
            Console.WriteLine("Задачи можно создавать только в статусе 'Проект'.");
            return;
        }

        var task = new Task(description, daysToComplete, initiator, isPeriodic, reportingInterval);

        if (isPeriodic && reportingInterval.HasValue)
        {
            task.reportingInterval = reportingInterval;
            task.reportCount = reportCount;
            task.nextReportDate = DateTime.Today;
        }

        project.tasks.Add(task);
    }



    public void StartProject(Project project)
    {
        if (project.status == ProjectStatus.Project)
        {
            project.status = ProjectStatus.Execution;
            Console.WriteLine($"Проект '{project.description}' переведен в статус 'Исполнение'.");
        }
        else
        {
            Console.WriteLine("Ошибка: Проект уже в статусе 'Исполнение' или 'Закрыт'.");
        }
    }

    public void DistributeTasks(Project project)
    {
        if (!team.Any())
        {
            Console.WriteLine("Нет исполнителей в команде.");
            return;
        }

        var random = new Random();
        foreach (var task in project.tasks.Where(t => t.performer == null))
        {
            task.performer = team[random.Next(team.Count)];
        }
    }

    public void RemoveTask(Project project, Task task)
    {
        if (project.tasks.Contains(task))
        {
            project.tasks.Remove(task);
            Console.WriteLine($"Тимлид '{GetName()}' удалил задачу '{task.description}' из проекта '{project.description}'.");
        }
    }
}