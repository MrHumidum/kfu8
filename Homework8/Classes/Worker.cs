using System;

namespace Homework8;
public class Worker : Employee
{
    public Worker(string name) : base(name) { }

    public void TakeTask(Task task)
    {
        if (task.performer == this && task.status == TaskStatus.Assigned)
        {
            task.UpdateStatus(TaskStatus.InProgress);
            Console.WriteLine($"Исполнитель '{GetName()}' взял задачу '{task.description}' в работу.");
        }
        else
        {
            Console.WriteLine("Ошибка: Задача уже в работе или назначена другому исполнителю.");
        }
    }

    public void TransferTask(Task task, Worker newWorker)
    {
        if (task.performer == this)
        {
            task.performer = newWorker;
            task.UpdateStatus(TaskStatus.Assigned);
            Console.WriteLine($"Задача '{task.description}' передана исполнителю '{newWorker.GetName()}'.");
        }
        else
        {
            Console.WriteLine("Ошибка: Задачу может передать только текущий исполнитель.");
        }
    }

    public void RefuseTask(Task task)
    {
        if (task.performer == this)
        {
            task.performer = null;
            task.UpdateStatus(TaskStatus.Assigned);
            Console.WriteLine($"Исполнитель '{GetName()}' отказался от задачи '{task.description}'.");
        }
        else
        {
            Console.WriteLine("Ошибка: Задачу может отказаться только текущий исполнитель.");
        }
    }

    public void AddReport(Task task, string content)
    {
        if (task.status != TaskStatus.InProgress)
        {
            Console.WriteLine("Ошибка: Задача должна быть в статусе 'В работе' для добавления отчета.");
            return;
        }

        var report = new Report(content, this);
        task.GetReports().Add(report);
        task.UpdateStatus(TaskStatus.UnderReview);
        Console.WriteLine($"Исполнитель '{GetName()}' добавил отчет по задаче '{task.description}'.");
    }
    public void SubmitPeriodicReport(string content, Task task)
    {
        if (task.isPeriodic && task.nextReportDate.HasValue && DateTime.Now >= task.nextReportDate)
        {
            var report = new Report(content, this);
            task.GetReports().Add(report);
            task.nextReportDate = DateTime.Now.Add(task.reportingInterval.Value);
            Console.WriteLine($"Исполнитель '{GetName()}' добавил отчет по задаче '{task.description}'.");

        }
    }
}