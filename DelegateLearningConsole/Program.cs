using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateLearningConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            //Perform differnt operations on same data
            ProcessData process = new ProcessData();
            BizRuleDelegate delAdd = (x, y) => x + y;
            BizRuleDelegate delMultiplication = (x, y) => x * y;
            process.Process(5, 2, delAdd);
            process.Process(5, 2, delMultiplication);


            //Action delegate : It accept only input and returns no value

            Action<int, int> actionAdd = (x, y) => Console.WriteLine($"Action Result: {x + y}");
            Action<int, int> actionMult = (x, y) => Console.WriteLine($"Action Result: {x * y}");
            process.ProcessAction(5, 2, actionAdd);
            process.ProcessAction(5, 2, actionMult);

            //Func delegate : It accept only input and returns a value

            Func<int, int, int> funcAdd = (x, y) => x + y;
            Func<int, int, int> funcMult = (x, y) => x * y;
            process.ProcessFunc(5, 2, funcAdd);
            process.ProcessFunc(5, 2, funcMult);

            var worker = new Worker();


            worker.WorkPerformed += new EventHandler<WorkEventArgs>(worker_WorkPerformed);
            worker.WorkCompleted += new EventHandler(worker_WorkCompleted);
            worker.WorkException += new EventHandler<WorkEventArgs>(worker_WorkExecption);


            worker.DoWork(10, WorkType.LeftHome);


            //WorkedPerformedHandler del1 = new WorkedPerformedHandler(PerformWork1);
            //WorkedPerformedHandler del2 = new WorkedPerformedHandler(PerformWork2);
            //DoWork(del1);
            //DoWork(del2);
            //worker.WorkCompleted += new EventHandler(worker_WorkCompleted);

            Console.ReadKey();
        }

        //static void DoWork(WorkedPerformedHandler work)
        //{
        //    work.Invoke(10, WorkType.GotoMeeting);
        //}


        static void worker_WorkPerformed(object sender, WorkEventArgs eventArgs)
        {
            Console.WriteLine($"Worked Hours : {eventArgs.Hour}  WorkType:   { eventArgs.WorkType.ToString()}");
        }
        static void worker_WorkCompleted(object sender, EventArgs eventArgs)
        {
            Console.WriteLine($"Work Compeleted");
        }
        static void worker_WorkExecption(object sender, WorkEventArgs eventArgs)
        {
            Console.WriteLine($"Exception Raised : " + eventArgs.WorkerException.Message);
        }
        //static void PerformWork1(int hour, WorkType WorkType)
        //{
        //    printConsole($"PerformWork1 > Work Type: {WorkType.ToString() } - Hour: {hour}");
        //}

        //static void PerformWork2(int hour, WorkType WorkType)
        //{
        //    printConsole($"PerformWork2 > Work Type: {WorkType.ToString() } - Hour: {hour}");
        //}

        //static void printConsole(string text)
        //{
        //    Console.WriteLine(text);
        //}
    }

    public enum WorkType
    {
        GotoMeeting,
        Golf,
        Cricket,
        LeftHome
    }
}
