﻿using System;
namespace twenty_questions
{
    public class ElevenToTwenty
    {
        public ElevenToTwenty()
        {
        }

        public void ReadFileExtensions(string[] filePaths)
        {
            Console.WriteLine("Q11: Reading the extensions of specified files");

            foreach (string path in filePaths)
            {
                string[] splitPath = path.Split('.');
                if (splitPath.Length == 2)
                {
                    Console.WriteLine($"{splitPath[1]}");
                } else Console.WriteLine($"{path} does not have a valid extension");
            }
        }

        public void SalaryClassifier()
        {
            Console.WriteLine("Q12: Classifying your salary");
            Console.WriteLine("Please input how much you earn");

            int salary = Convert.ToInt32(Console.ReadLine());

            switch (salary)
            {
                case <= 0:
                    Console.WriteLine("Only positive numbers are allowed");
                    break;
                case < 50000:
                    Console.WriteLine("You are a Basic Earner");
                    break;
                case < 200000:
                    Console.WriteLine("You are a Mid Earner");
                    break;
                default:
                    Console.WriteLine("You are a High Earner");
                    break;
            }
            return;
        }
    }
}
