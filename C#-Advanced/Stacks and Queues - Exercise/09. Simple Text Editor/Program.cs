using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace _9.Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var stack = new Stack<string>();
            while (n != 0)
            {
                n--;
                var command = Console.ReadLine().Split();
                if (command[0] == "1")//добавя елемент
                {
                    stack.Push(command[1]);
                }
                else if (command[0] == "2")//премахва брой символи
                {
                    if (!stack.Any())
                    {
                        break;
                    }
                    else
                    {
                        int remove = int.Parse(command[1]);
                        var name = stack.Peek();
                        int lenght = name.Length - remove;

                            if (lenght!=0)
                            {
                            string symbol = name.Substring(0,lenght);
                                stack.Push(symbol);
                            }
                            else
                            {
                                stack.Push("");
                            }
                    }
                }
                else if (command[0] == "3")//принтира символ
                {
                    int index = int.Parse(command[1]);
                    if (!stack.Any())
                    {
                        break;
                    }
                    else
                    {
                        foreach (var item in stack)
                        {
                            for (int i = 0; i < item.Length; i++)
                            {
                                if (index - 1 == i)
                                {
                                    Console.WriteLine(item[index - 1]);
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
                else if (command[0] == "4")//връща команда
                {
                        stack.Pop();
                }
            }
        }
    }
}
