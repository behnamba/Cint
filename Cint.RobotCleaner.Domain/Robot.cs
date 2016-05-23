using Cint.RobotCleaner.Domain.Base;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Cint.RobotCleaner.Domain
{
    public class Robot : IRobot
    {
        public const int MaxTasksCount = 10000;
        public const int MinTasksCount = 0;

        List<CleanTask> CleanTasks;

        ILogger _logger;

        public bool IsValid
        {
            get
            {
                return TasksCount == CleanTasks.Count;
            }
        }

        int _TasksCount;
        public int TasksCount
        {
            get
            {
                return _TasksCount;
            }
            set
            {
                if (value < MinTasksCount)
                {
                    TasksCount = MinTasksCount;
                }
                else if (value > MaxTasksCount)
                {
                    TasksCount = MaxTasksCount;
                }
                else
                {
                    _TasksCount = value;
                }
            }
        }

        public Point CurrentPosition { get; set; }

        public Robot(ILogger logger)
        {
            _logger = logger;
            CleanTasks = new List<CleanTask>();
        }

        public void AddCleanTask(string command)
        {
            CleanTasks.Add(new CleanTask(command));
        }

        public void DoCleaning()
        {
            foreach (var item in CleanTasks)
            {
                CurrentPosition = item.DoClean(CurrentPosition, _logger);
            }
        }

        public string Display()
        {
            return _logger.ReadLog();
        }
    }
}