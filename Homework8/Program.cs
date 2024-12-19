using System;

namespace Homework8
{
    class Program
    {
        static void Main(string[] args)
        {
            //             Написать программу, содержащую решение следующих задач:
            // Task Manager
            // У команды из IT компании существует программа, где они контролируют свои текущие
            // задачи – что-то типа Task Manager. Существует проекты по каждому проекту создаются
            // задачи.
            // Сущность Проект может быть в трех статусах: Проект, Исполнение, Закрыт.
            // У проекта есть:

            // ● описание проекта,
            // ● сроки выполнения
            // ● инициатор проекта(заказчик)
            // ● человек, ответственный за проект(тимлид)
            // ● задачи по проекту
            // ● статус
            // Задачи по проекту назначает только один человек(тимлид) Сущность Задача может быть в
            // четырех статусах: Назначена, В работе, На проверке, Выполнена.
            // У задачи есть:
            // ● описание задачи,
            // ● сроки задачи,
            // ● инициатор задачи.
            // ● исполнитель,
            // ● статус задачи
            // ● отчет(ы) по задаче
            // Сущность Отчёт:
            // ● текст отчета,
            // ● дата выполнения,
            // ● исполнитель.
            // Описание процесса:
            // Создается проект с определенными сроками. Далее ответственный за проект создает задачи
            // по этому проекту.
            // Задачи можно создавать только в статусе проекта «Проект». После того, как все проекты
            // назначены необходимо перевести проект в статус «Исполнение».
            // Задачи приходят исполнителям в статусе «Назначена». Исполнитель может взять задачу в
            // работу, делегировать ее другому человеку или отклонить. Если человек берет задачу в
            // работу, то задача переходит в статус «В работе», если он делегировал эту задачу, то меняется
            // исполнитель, а статус становится «Назначена», при отклонении задачи, задача не имеет
            // Исполнителя и Человек, назначивший задачу, может ее назначить кому-то другому или
            // удалить эту задачу вообще. По каждой задаче создается отчет по выполненной работе.
            // Отчет приходит инициатору на проверку.
            // Отчет можно утвердить или вернуть на доработку. Проект считается закрытым, если по
            // нему выполнены все задачи. Необходимо создать 10 человек команды, каждый человек
            // должен получить минимум одну задачу.
            // Проект минимум 1.
            // *Обязательно*
            // Задача разовая. По одной задаче создается один отчёт.

            // *На дополнительные размышления(только для желающих)*
            // Задачи могут быть периодические. Например, задачу можно дать на год с периодом
            // отчетности раз в месяц, тогда нужно собрать 12 отчетов.
            // Предусмотрите один из сценариев, но лучше все:
            // ● Отчитываться каждый рабочий день,
            // ● Отчитываться раз в неделю,
            // ● Отчитываться раз в месяц и выбрать день.
            // Проект считается закрытым, если по нему выполнены все задачи.


            var customer = new Customer("Иван");
            var teamlead = new Teamlead("Ольга");

            var project = customer.CreateProject("Разработка системы", 30, teamlead);

            var workers = new List<Worker> {
                new Worker("Алексей"),
                new Worker("Марина"),
                new Worker("Дмитрий"),
                new Worker("Елена"),
                new Worker("Сергей"),
                new Worker("Анна"),
                new Worker("Олег"),
                new Worker("Наталья"),
                new Worker("Игорь"),
                new Worker("Татьяна")
            };

            foreach (var worker in workers)
            {
                teamlead.AddWorkerToTeam(worker);
            }

            teamlead.CreateTask(project, "Собрать требования", 5, customer);
            teamlead.CreateTask(project, "Реализовать функционал", 20, customer);
            teamlead.CreateTask(project, "Собрать требования", 5, customer);
            teamlead.CreateTask(project, "Разработать архитектуру", 10, customer, true, TimeSpan.FromSeconds(5), 5);
            teamlead.CreateTask(project, "Реализовать функционал", 20, customer);
            teamlead.CreateTask(project, "Протестировать функционал", 8, customer);
            teamlead.CreateTask(project, "Подготовить документацию", 12, customer);
            teamlead.CreateTask(project, "Провести обучение пользователей", 15, customer);
            teamlead.CreateTask(project, "Оптимизировать производительность", 10, customer, true, TimeSpan.FromSeconds(10), 3);
            teamlead.CreateTask(project, "Настроить серверное окружение", 7, customer);
            teamlead.CreateTask(project, "Обновить систему безопасности", 6, customer);
            teamlead.CreateTask(project, "Сделать релиз", 3, customer);



            teamlead.StartProject(project);

            teamlead.DistributeTasks(project);

            foreach (var task in project.tasks)
            {
                if (task.performer != null)
                {
                    task.performer.TakeTask(task);

                    if (task.isPeriodic && task.reportingInterval.HasValue)
                    {
                        DateTime endDate = DateTime.Today.AddDays(task.daysToComplete);
                        int reportCounter = 0;

                        while (task.nextReportDate.HasValue && task.nextReportDate <= endDate && reportCounter < task.reportCount)
                        {
                            task.performer.SubmitPeriodicReport($"Периодический отчет по задаче '{task.description}'", task);
                            reportCounter++;

                            task.nextReportDate = task.nextReportDate.Value.Add(task.reportingInterval.Value);
                        }
                    }

                    else
                    {
                        task.performer.AddReport(task, $"Задача '{task.description}' выполнена.");
                        task.UpdateStatus(TaskStatus.Completed);
                    }
                }
                else
                {
                    Console.WriteLine($"Задача '{task.description}' не назначена исполнителю.");
                }
            }



            if (project.tasks.All(t => t.status == TaskStatus.Completed))
            {
                project.UpdateStatus(ProjectStatus.Closed);
                Console.WriteLine($"Проект '{project.description}' завершен.");
            }
        }
    }
}


