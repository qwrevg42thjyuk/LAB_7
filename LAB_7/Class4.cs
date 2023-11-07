using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_7
{
    internal class Class4
    {
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

public class TaskScheduler<TTask, TPriority>
{
    private List<TTask> taskQueue = new List<TTask>();
    private Dictionary<TTask, TPriority> taskPriorities = new Dictionary<TTask, TPriority>();
    private Func<TTask, TPriority> priorityDelegate;
    private Func<TTask> objectInitializer;
    private Action<TTask> objectDisposer;

    public TaskScheduler(Func<TTask, TPriority> priorityFunc, Func<TTask> initializer, Action<TTask> disposer)
    {
        priorityDelegate = priorityFunc;
        objectInitializer = initializer;
        objectDisposer = disposer;
    }

    public void AddTask(TTask task)
    {
        TPriority priority = priorityDelegate(task);
        taskQueue.Add(task);
        taskPriorities[task] = priority;
        taskQueue = taskQueue.OrderBy(t => taskPriorities[t]).ToList();
    }

    public TTask GetNextTask()
    {
        if (taskQueue.Count > 0)
        {
            TTask task = taskQueue[0];
            taskQueue.RemoveAt(0);
            return task;
        }
        return default(TTask);
    }

    public void ExecuteNext()
    {
        TTask task = GetNextTask();
        if (task != null)
        {
            ExecuteTask(task);
        }
    }

    private void ExecuteTask(TTask task)
    {
        if (objectInitializer != null)
            objectInitializer(task);

        // Виконайте логіку завдання тут.

        if (objectDisposer != null)
            objectDisposer(task);
    }
}
