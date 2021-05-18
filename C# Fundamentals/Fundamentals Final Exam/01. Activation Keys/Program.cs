--57 score
using System;
 
namespace ActivationKeys 
{
    class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Generate")
            {
                string[] commandArray = command.Split(">>>");
                if (commandArray[0] == "Contains")
                {
                    string substring = commandArray[1];
                    if (activationKey.Contains(substring))
                    {
                        Console.WriteLine($"{activationKey} contains {substring}");
                    }
 
                    else if(activationKey.Contains(substring)==false)
                    {
                        Console.WriteLine($"Substring not found!");
                    }
                }
 
                else if (commandArray[0] == "Flip")
                {
                    if (commandArray[1] == "Upper")
                    {
                        int startIndex = int.Parse(commandArray[2]);
                        int endIndex = int.Parse(commandArray[3]);
                        int validStartIndex = Math.Max(0, startIndex);
                        int validEndInex = Math.Min(activationKey.Length - 1, endIndex);
                        if (validEndInex >= validStartIndex)
                        {
                            int subtringToReplaceLength = endIndex - startIndex;
                            string substringToReplace = activationKey.Substring(startIndex, subtringToReplaceLength);
                            string newString = substringToReplace.ToUpper();
                            activationKey = activationKey.Replace(substringToReplace, newString);                         
                        }
 
                        Console.WriteLine(activationKey);
                    }
 
                    else if (commandArray[1] == "Lower")
                    {
                        int startIndex = int.Parse(commandArray[2]);
                        int endIndex = int.Parse(commandArray[3]);
                        int validStartIndex = Math.Max(0, startIndex);
                        int validEndInex = Math.Min(activationKey.Length - 1, endIndex);
                        if (validEndInex >= validStartIndex)
                        {
                            int subtringToReplaceLength = endIndex - startIndex;
                            string substringToReplace = activationKey.Substring(validStartIndex, subtringToReplaceLength);
                            string newString = substringToReplace.ToLower();
                            activationKey = activationKey.Replace(substringToReplace, newString);
                        }
 
                        Console.WriteLine(activationKey);
                    }                   
                }
 
                else if (commandArray[0] == "Slice")
                {
                    int startIndex = int.Parse(commandArray[1]);
                    int endIndex = int.Parse(commandArray[2]);
                    int validStartIndex = Math.Max(0, startIndex);
                    int validEndIndex = Math.Min(activationKey.Length - 1, endIndex);
                    if (validEndIndex >= validStartIndex)
                    {
                        int substringToRemoveLength = validEndIndex - validStartIndex;
                        string substringToRemove = activationKey.Substring(validStartIndex, substringToRemoveLength);
                        activationKey = activationKey.Replace(substringToRemove, new string(""));
                    }
 
                    Console.WriteLine(activationKey);
                }
            }
 
            Console.WriteLine($"Your activation key is: { activationKey}");           
        }
    }
}
