using System.Diagnostics;
using System.Linq.Expressions;

namespace ConsoleСalculatorUser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter expression in the following format: \"<int operand1> <operator> <int operand2>\" : ");
            string input = Console.ReadLine();

            string[] expression = input.Split(' ');

            int result;

            Process simpleConsoleCalculator = new Process();

            simpleConsoleCalculator.StartInfo.FileName = "SimpleConsoleCalculator.exe";
            simpleConsoleCalculator.StartInfo.Arguments = input;

            simpleConsoleCalculator.StartInfo.RedirectStandardOutput = true;
            simpleConsoleCalculator.StartInfo.CreateNoWindow = true;

            simpleConsoleCalculator.Start();
            simpleConsoleCalculator.WaitForExit();

            result = simpleConsoleCalculator.ExitCode;

            Console.WriteLine($"Result: {result}");
        }
    }
}