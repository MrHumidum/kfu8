using System;

namespace Homework8;
public class Report
{
    public string content;
    public DateTime executionDate;
    public Worker executor;
    public Report(string content, Worker executor)
    {
        this.content = content;
        this.executor = executor;
        executionDate = DateTime.Today;
    }
    public override string ToString()
    {
        return $"Дата: {executionDate:G} - Исполнитель: {executor.GetName()} - Отчёт: {content}";
    }
}