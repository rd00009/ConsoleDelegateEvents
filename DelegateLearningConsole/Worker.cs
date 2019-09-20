using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateLearningConsole
{
    public delegate void WorkedPerformedHandler(int hour, WorkType WorkType);
    public delegate int BizRuleDelegate(int x, int y);
    public class Worker
    {
        //public event WorkedPerformedHandler WorkPerformed;
        public event EventHandler<WorkEventArgs> WorkPerformed;
        public event EventHandler WorkCompleted;
        public event EventHandler<WorkEventArgs> WorkException;
        public void DoWork(int hour, WorkType WorkType)
        {
            for (int i = 0; i < hour; i++)
            {

                //Raise Event WorkedPerformed

                try
                {
                    if (i == 2)
                    {
                        throw new Exception("Some exception is current process");
                    }
                    OnWorkPerformed(i + 1, WorkType);
                }
                catch (Exception ex)
                {
                    OnWorkException(i + 1, ex);
                }

                System.Threading.Thread.Sleep(5000);
            }
            //Raise Event Completed
            OnWorkCompleted();
        }

        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            WorkPerformed?.Invoke(hours, new WorkEventArgs(hours, workType));//Way 1
            //var del = WorkPerformed as WorkedPerformedHandler; //Way2
            //del?.Invoke(hours, workType);
        }

        protected virtual void OnWorkCompleted()
        {
            WorkCompleted?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnWorkException(int hours, Exception ex)
        {
            WorkException?.Invoke(this, new WorkEventArgs(hours, ex));
        }
    }
}
