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


        /*
         Displays Congratulations! only if all the generated numbers are odd
         */
        public void Lottery()
        {
            string success = "Congratulations, you have beaten the game!";
            string failure = "Sorry, You have not won this time.";

            Boolean inPlay = true;
            Random rnd = new Random();

            string result;
            Boolean won;

            while (inPlay)
            {
                result = "";
                won = true;
                Console.WriteLine("Please press any key to play this game");
                Console.ReadLine();

                for (int i = 0; i < 3; i++)
                {
                    int num = rnd.Next(10);
                    if (num % 2 == 0) won = false;
                    result += Convert.ToString(num) + " ";
                }

                Console.WriteLine($"Your number is {result.Trim()}");

                Console.WriteLine((won ? success : failure) + "\nPlay Again? (y/n)");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "y":
                        inPlay = true;
                        break;
                    case "n":
                        inPlay = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input. Exiting game...");
                        inPlay = false;
                        break;
                }
            }
            Console.WriteLine("Thanks for playing. See you around!");
        }
    }
}

