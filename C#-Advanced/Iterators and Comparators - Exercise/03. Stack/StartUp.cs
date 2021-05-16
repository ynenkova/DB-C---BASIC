using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>(new List<int>());

            var cmdArgs = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            while (cmdArgs[0] != "END")
            {
                switch (cmdArgs[0])
                {
                    case "Push":
                        var elements = cmdArgs.Skip(1).Select(int.Parse);
                        stack.Push(elements);
                        break;
                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (ArgumentException ae)
                        {
                            Console.WriteLine(ae.Message);
                        }

                        break;
                    default:
                        break;
                }

                cmdArgs = Console.ReadLine()
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            }

            PrintStack(stack);
            PrintStack(stack);
            
        }
        public static void PrintStack(Stack<int>stack)
        {
            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }
        }
    }
}
