using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//任务模块
public partial class TaskModule : Singleton<TaskModule>
{
    //任务字典 <任务类型-任务列表>
    private Dictionary<TaskType, List<TaskData>> m_taskDict = new Dictionary<TaskType, List<TaskData>>();

    //当前正在执行的任务
    public TaskData CurrentTask
    {
        get
        {
            TaskData lastTask = null;
            foreach (var tasks in m_taskDict.Values)
            {
                if (lastTask == null)
                {
                    foreach (var task in tasks)
                    {
                        if (task.isExecuting)
                        {
                            lastTask = task;
                            break;
                        }
                    }
                }
                else
                {
                    break;
                }
            }
            return lastTask;
        }
    }

    //是否存在任务
    public int IsTaskExist(TaskType type, int configId)
    {
        int index = -1;

        List<TaskData> tasks;
        if (!m_taskDict.TryGetValue(type, out tasks))
        {
            tasks = new List<TaskData>();
            m_taskDict.Add(type, tasks);
        }

        for (int i = 0; i < tasks.Count; i++)
        {
            if (configId == tasks[i].configId)
            {
                index = i;
                break;
            }
        }
        return index;
    }

    //添加任务
    public void AddTask(TaskData data)
    {
        int index = IsTaskExist(data.type, data.configId);
        if (index < 0)
        {
            m_taskDict[data.type].Add(data);
        }
        else
        {
            m_taskDict[data.type][index] = data;
        }
    }

    //查找任务
    public TaskData GetTask(TaskType type, int configId)
    {
        int index = IsTaskExist(type, configId);
        if (index < 0)
        {
            return null;
        }
        else
        {
            return m_taskDict[type][index];
        }
    }
}