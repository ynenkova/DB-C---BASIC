using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace _10.LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            int[] lBugInitialPositionIndex = Console.ReadLine()     
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] ladyBugField = new int[fieldSize];

            for (int i = 0; i < ladyBugField.Length; i++)  
            {
                if (lBugInitialPositionIndex.Contains(i))
                {
                    ladyBugField[i] = 1;
                }
            }

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] rules = command
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int initialPosition = int.Parse(rules[0]);
                string direction = rules[1];
                int countOfMoves = int.Parse(rules[2]);

                int newPosition = 0;

                if (countOfMoves < 0)
                {
                    if (direction == "left")
                    {
                        direction = "right";
                        countOfMoves = Math.Abs(countOfMoves);
                    }
                    else if (direction == "right")
                    {
                        direction = "left";
                        countOfMoves = Math.Abs(countOfMoves);
                    }
                }

                if (initialPosition < 0    
                   || initialPosition > ladyBugField.Length - 1
                   || ladyBugField[initialPosition] == 0)
                {
                    command = Console.ReadLine();
                    continue;
                }

                if (countOfMoves == 0 && initialPosition >= 0 && initialPosition <= ladyBugField.Length - 1)
                {
                    if (ladyBugField[initialPosition] == 1)
                    {
                        ladyBugField[initialPosition] = 0;
                    }

                }

                switch (direction)
                {

                    case "right":

                        newPosition = initialPosition + countOfMoves; 

                        ladyBugField[initialPosition] = 0; 

                        if (newPosition > ladyBugField.Length - 1) 
                        {
                            ladyBugField[initialPosition] = 0;  
                            break;
                        }
                        else
                        {
                            for (int i = newPosition; i < ladyBugField.Length; i += countOfMoves) 
                            {
                                if (ladyBugField[i] == 0)
                                {
                                    ladyBugField[i] = 1;
                                    break;
                                }
                            }

                        }
                        break;

                    case "left":

                        newPosition = initialPosition - countOfMoves;


                        ladyBugField[initialPosition] = 0; 
                        if (newPosition < 0) 
                        {
                            ladyBugField[initialPosition] = 0;
                            break;
                        }

                        else
                        {
                            for (int i = newPosition; i >= 0; i -= countOfMoves) 
                            {
                                if (ladyBugField[i] == 0) 
                                {
                                    ladyBugField[i] = 1;
                                    break;
                                }
                            }

                        }
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", ladyBugField));

        }
    }
}
