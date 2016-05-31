using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//多播委托
namespace cook_book.ch_01
{
    class ch_01_15
    {
        public static void InvokeinReverse()
        {
            Func<int> myDelegateInstance1 = TestInvokeIntReturn.Method1;
            Func<int> myDelegateInstance2 = TestInvokeIntReturn.Method2;
            Func<int> myDelegateInstance3 = TestInvokeIntReturn.Method3;

            Func<int> allInstance = myDelegateInstance1 + myDelegateInstance2 + myDelegateInstance3;

            Console.WriteLine("Fire delegates in reverse");
            Delegate[] delegateList = allInstance.GetInvocationList();
            foreach (Func<int> instance in delegateList)
            {
                int retVal = instance();
                Console.WriteLine($"Delegate returned {retVal}");
            }
        }
    }

    public class TestInvokeIntReturn
    {
        public static int Method1()
        {
            Console.WriteLine("Invoked Method1");
            return 1;
        }

        public static int Method2()
        {
            Console.WriteLine("Invoked Method2");
            return 2;
        }

        public static int Method3()
        {
            Console.WriteLine("Invoked Method3");
            return 3;
        }
    }
}
