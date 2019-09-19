using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateLearningConsole
{
    public class WorkEventArgs : EventArgs
    {
        public int Hour { get; set; }
        public WorkType WorkType { get; set; }

        public Exception WorkerException { get; set; }

        public WorkEventArgs(int hour, WorkType workType)
        {
            Hour = hour;
            WorkType = workType;
        }

        public WorkEventArgs(int hour, Exception ex)
        {
            Hour = hour;
            WorkerException = ex;
        }
    }
}
