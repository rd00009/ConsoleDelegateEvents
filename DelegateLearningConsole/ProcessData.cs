using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateLearningConsole
{
    public class ProcessData
    {
        public int Process(int x, int y, BizRuleDelegate del)
        {
            int result = del(x, y);
            Console.WriteLine($"Result: { result}");
            return result;
        }

        public void ProcessAction(int x, int y, Action<int, int> delAction)
        {
            delAction(x, y);
        }

        public int ProcessFunc(int x, int y, Func<int, int, int> delFun)
        {
            int result = delFun(x, y);
            Console.WriteLine($"Func Result: { result}");
            return result;
        }
    }
}
