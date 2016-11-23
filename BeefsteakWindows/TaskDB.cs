using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeefsteakWindows
{
    /// <summary>
    /// Main task database for the application
    /// </summary>
    class TaskDB
    {
        /// <summary>
        /// Internally held list of tasks.
        /// </summary>
        /// <remarks>
        /// Observable because it is used in VM's.
        /// </remarks>
        private static ObservableCollection<TomatoTask> _task_list = new ObservableCollection<TomatoTask>();

        /// <summary>
        /// Return the list of tasks.
        /// </summary>
        public static ObservableCollection<TomatoTask> Tasks
        {
            get
            {
                return _task_list;
            }
        }

        /// <summary>
        /// Add a task to the internal list.
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public static TomatoTask AddTask(string title)
        {
            var t = new TomatoTask() { Title = title, Id = Guid.NewGuid(), NumberDone = 0, NumberToDo = 1 };
            _task_list.Add(t);
            return t;
        }

        /// <summary>
        /// Find a task. Throw if nothing there.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static TomatoTask FindTask(Guid id)
        {
            var t = _task_list.Where(my => my.Id == id).FirstOrDefault();
            if (t == null)
            {
                throw new ArgumentException("Task was not found");
            }
            return t;
        }
    }
}
