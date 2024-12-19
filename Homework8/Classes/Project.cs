using System;

namespace Homework8;
public class Project
{

    public string description;
    public DateTime deadline;

    public readonly Customer Initiator;
    public readonly Teamlead teamlead;
    public List<Task> tasks;
    public ProjectStatus status;

    public Project(string description, int deadline, Customer Initiator, Teamlead teamlead, List<Task> tasks)
    {
        this.description = description;
        this.deadline = DateTime.Today.AddDays(deadline);
        this.Initiator = Initiator;
        this.teamlead = teamlead;
        this.tasks = tasks;
        this.status = ProjectStatus.Project;
    }

    public List<Task> GetTasks()
    {
        return tasks;
    }
    public void UpdateStatus(ProjectStatus newStatus)
    {
        status = newStatus;
    }
}