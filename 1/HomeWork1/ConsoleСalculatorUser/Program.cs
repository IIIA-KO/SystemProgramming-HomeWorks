﻿using System.Diagnostics;

namespace ConsoleСalculatorUser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter expression in the following format: \"<int operand1> <operator> <int operand2>\" : ");
            string input = Console.ReadLine();

            int result;

            Process simpleConsoleCalculator = new Process();

            simpleConsoleCalculator.StartInfo.FileName = "D:\\ІЛЛЯ\\ШАГ\\2023-24\\Системне програмування\\HomeWork\\1\\HomeWork1\\SimpleConsoleCalculator\\bin\\Debug\\net7.0\\SimpleConsoleCalculator.exe";
            simpleConsoleCalculator.StartInfo.Arguments = input;

            simpleConsoleCalculator.StartInfo.RedirectStandardOutput = true;

            simpleConsoleCalculator.StartInfo.RedirectStandardError = true;
            simpleConsoleCalculator.OutputDataReceived += (sender, args) => Console.WriteLine(args.Data);
            simpleConsoleCalculator.ErrorDataReceived += (sender, args) => Console.WriteLine($"Error:{args.Data}");

            simpleConsoleCalculator.Start();
            simpleConsoleCalculator.WaitForExit();

            result = simpleConsoleCalculator.ExitCode;

            Console.WriteLine($"Result: {result}");
        }
    }
}