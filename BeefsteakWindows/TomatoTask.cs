using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeefsteakWindows
{
    /// <summary>
    /// All the info required to do a tomato task
    /// </summary>
    public class TomatoTask
    {
        /// <summary>
        /// The name of this task given by the user
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Number the user expects to be done for this task.
        /// </summary>
        public int NumberToDo { get; set; }

        /// <summary>
        /// Number already done on this task
        /// </summary>
        public int NumberDone { get; set; }

        /// <summary>
        /// Set the GUID for this task. Should never be modified
        /// </summary>
        public Guid Id { get; set; }
    }
}
