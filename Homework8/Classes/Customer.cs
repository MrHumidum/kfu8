using System;

namespace Homework8;
public class Customer : Employee
{
    public Customer(string name) : base(name)
    {
    }
    public Project CreateProject(string description, int deadlineDays, Teamlead teamlead)
    {
        var project = new Project(description, deadlineDays, this, teamlead, new List<Task>());
        Console.WriteLine($"Заказчик '{GetName()}' создал проект '{description}' со сроком {deadlineDays} дней.");
        return project;
    }

}