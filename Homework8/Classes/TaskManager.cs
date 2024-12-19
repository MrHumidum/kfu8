using System;

namespace Homework8;
public class TaskManager
{
    public List<Project> projects;
    public List<Worker> workers;
    public List<Customer> customers;


    private Random random = new Random();
    public TaskManager()
    {
        projects = new List<Project>();
        workers = new List<Worker>();
        customers = new List<Customer>();
    }

    public void CreateTeam(List<string> workerNames)
    {
        foreach (var name in workerNames)
        {
            workers.Add(new Worker(name));
        }
    }

    public void AddCustomer(string name)
    {
        customers.Add(new Customer(name));
    }

    public void CreateTeam(string teamleadName, List<string> workerNames)
    {
        var teamlead = new Teamlead(teamleadName);
        foreach (var name in workerNames)
        {
            var worker = new Worker(name);
            teamlead.AddWorkerToTeam(worker);
            workers.Add(worker);
        }
    }
    public void CloseProjectIfAllTasksCompleted(Project project)
    {
        if (project.tasks.All(task => task.status == TaskStatus.Completed))
        {
            project.status = ProjectStatus.Closed;
            Console.WriteLine($"Проект '{project.description}' закрыт.");
        }
    }

    public void PrintProjects()
    {
        foreach (var project in projects)
        {
            Console.WriteLine($"Проект: {project.description}, Статус: {project.status}, Дедлайн: {project.deadline.ToShortDateString()}");
            foreach (var task in project.tasks)
            {
                Console.WriteLine($"\t{task}");
            }
        }
    }

}
