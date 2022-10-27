using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace twenty_questions
{
    public class OneToTen
    {
        public OneToTen()
        {
        }

        public void NameConcatenation()
        {
            Console.WriteLine("Please enter your First Name: ");
            string firstName = Console.ReadLine();

            Console.WriteLine("Please enter your Last Name: ");
            string lastName = Console.ReadLine();

            int age;
            while (true)
            {
                Console.WriteLine("Enter your Age: ");
                try
                {
                    age = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Please enter a valid number as your age");
                }
            }

            int currentYear = DateTime.Now.Year;
            int birthYear = currentYear - age;

            string gender;
            string genderNoun;

            while (true)
            {
                try
                {
                    Console.WriteLine("Please choose a gender:\n1. Male (1/M/Male)\n2. Female(2/F/Female)");
                    gender = Console.ReadLine().ToLower();

                    switch (gender)
                    {
                        case "1":
                        case "m":
                        case "male":
                            genderNoun = "Son";
                            break;

                        case "2":
                        case "f":
                        case "female":
                            genderNoun = "Daughter";
                            break;
                        default:
                            throw new FormatException();
                    }
                    break;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Please enter a valid gender");
                }
            }

            Console.WriteLine($"Welcome, {firstName}, {genderNoun} of {lastName}, born in {birthYear}");
            Console.Read();
        }
    }
}

