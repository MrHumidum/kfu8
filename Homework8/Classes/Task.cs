using System;

namespace Homework8;
public class Task
{
    public string description;
    public DateTime deadlines;
    public readonly Customer initiator;

    public Worker? performer;
    public TaskStatus status;
    List<Report> reports;
    public bool isPeriodic;
    public int daysToComplete;
    public TimeSpan? reportingInterval;
    public DateTime? nextReportDate;
    public int reportCount;
    public Task(string description, int daysToComplete, Customer initiator, bool isPeriodic = false, TimeSpan? reportingInterval = null, int reportCount = 1)

    {
        this.description = description;
        this.deadlines = DateTime.Today.AddDays(daysToComplete);
        this.initiator = initiator;
        this.performer = null;
        this.status = TaskStatus.Assigned;
        reports = new List<Report>();
        this.description = description;
        this.daysToComplete = daysToComplete;
        this.initiator = initiator;
        this.status = TaskStatus.Assigned;
        this.reports = new List<Report>();
        this.reportCount = reportCount;
        this.isPeriodic = isPeriodic;
        this.reportingInterval = reportingInterval;
        if (isPeriodic && reportingInterval.HasValue)
        {
            this.nextReportDate = DateTime.Now.Add(reportingInterval.Value);
        }
    }
    public void UpdateStatus(TaskStatus newStatus)
    {
        status = newStatus;
    }

    public List<Report> GetReports() => reports;

    public override string ToString()
    {
        return $"Задача: {description}, Статус: {status}, Исполнитель: {(performer != null ? performer.GetName() : "Не назначен")}, Дедлайн: {deadlines.ToShortDateString()}";
    }


}

