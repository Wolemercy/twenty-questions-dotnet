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

        /*
         Displays a user's basic information
         */
        public void NameConcatenation()
        {
            Console.WriteLine("Question 1: Name Concatenation");

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
            Console.WriteLine("Question 2: Lottery");

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

        /*
         Displays a user's input in reversed order (Each word is reversed)
        */
        public void WordInReverse()
        {
            Console.WriteLine("Question 3: Word in Reverse");

            Console.WriteLine("Please enter the input you want reversed");

            string userInput = Console.ReadLine();

            string[] splitString = userInput.Split(' ');

            string result = "";

            foreach (string s in splitString) {
                char[] sChar = s.ToCharArray();
                Array.Reverse(sChar);
                result += new String(sChar) + " ";
            }

            Console.WriteLine($"Your reversed input is: {result.Trim()}");
            Console.Read();
        }

        /*
         Requests user to type the reverse of a random word. Return Pass or Fail depending on outcome
        */
        public void TypeInReverse()
        {
            Console.WriteLine("Question 4: Type in Reverse");

            Random rd = new Random();
            const string chars = "abcdefghijklmnopqrstuvwzyz";
            int wordLength = rd.Next(1, 6);

            string originalWord = "";
            for (int i = 0; i < wordLength; i++)
            {
                originalWord += chars[rd.Next(0, 26)];
            }

            string reversedWord = "";
            for (int i = wordLength - 1; i >= 0; i--)
            {
                reversedWord += originalWord[i];
            }

            Console.WriteLine($"Enter the reverse of this word: {originalWord}");
            string userInput = Console.ReadLine();

            if (userInput == reversedWord) Console.WriteLine("Spot on!");
            else Console.WriteLine("You got it wrong");
        }

        public void TemperatureUnitConversion()
        {
            Console.WriteLine("Question 5: Temperature Unit Conversion\n");

            string _capitalizeFirstLetter(string word) => char.ToUpper(word[0]) + word.Substring(1).ToLower();

            double fahToCel(double fah) => (fah - 32.0) * 5.0 / 9.0;
            double celToFah(double cel) => (cel * 9.0 / 5.0) + 32.0;


            Console.WriteLine("Please enter an option:\n1. Celsius to Fahrenheit\n2. Fahrenheit to Celsius");


            Boolean processing = true;
            int option = 0;

            while (processing)
            {
                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                    if (option > 2 || option < 1) throw new NotSupportedException();
                    processing = false;
                    break;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("You have entered an invalid value. Please enter either 1 or 2");
                }

                catch(NotSupportedException ex)
                {
                    Console.WriteLine("You have entered an invalid option. Please enter either 1 or 2");
                }

            }

            Console.WriteLine("Enter a {0} value: ", option == 1 ? "Celsius" : "Fahrenheit");

            try
            {
                switch (option)
                {
                    case 1:
                        double celsiusValue = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine($"Converting {celsiusValue} Celsius to Fahrenheit\nProcessing...\nProcessing Complete!\nResult: {celToFah(celsiusValue)} Fahrenheit");
                        break;
                    case 2:
                        double fahrenheitValue = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine($"Converting {fahrenheitValue} Fahrenheit to Celsius \nProcessing...\nProcessing Complete!\nResult: {fahToCel(fahrenheitValue)} Celsius");
                        break;
                }
            }
            catch (FormatException ex)
            {
                {
                    Console.WriteLine("You have entered an invalid value");
                }
            }

            Console.WriteLine("Thank you for using this Temperature Unit Converter");
        }

        public void MultiplicationTable(int start, int end)
        {
            Console.WriteLine($"Generating Multiplication table for numbers {start} through {end}\n");

            if (start < 1 || end > 12 || start >= end)
            {
                Console.WriteLine("Start value must be at least 1 and End value must be at most 12");
                return;
            }


            int rowLength = end - start + 1;
            int columnLength = end - start + 1;
            List<List<int>> table = new List<List<int>>();
            for (int i = 1; i <= end; i++)
            {
                table.Add(new List<int>());
                for (int j = start; j <= end; j++)
                {
                    
                    table[i - 1].Add(i * j);
                }
            }

            for (int i = 0; i < end; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    int num = table[i][j];
                    int space = num >= 100 ? 1 : num >= 10 ? 2 : 3; 
                    Console.Write(num + string.Concat(Enumerable.Repeat(" ", space)));
                }
                Console.WriteLine("\n");
            }
        }

        public void ReadLineByLine(string filePath)
        {
            Console.WriteLine($"Reading {filePath} line by line");
            if (File.Exists(filePath))
            {
                using(StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        Console.WriteLine(sr.ReadLine());
                    }
                }
            } else Console.WriteLine("The specified file does not exist");
            
        }

        public void CombineTwoFiles(string filePath1, string filePath2)
        {
            Console.WriteLine($"Combining {filePath1} and {filePath2}");
            if (File.Exists(filePath1) && File.Exists(filePath2))
            {
                using(StreamReader sr1 = new StreamReader(filePath1),
                    sr2 = new StreamReader(filePath2))
                {
                    while(!sr1.EndOfStream || !sr2.EndOfStream)
                    {
                        string line1 = sr1.EndOfStream ? "" : sr1.ReadLine();
                        string line2 = sr2.EndOfStream ? "" : sr2.ReadLine();

                        Console.WriteLine(line1 + line2);
                    }
                }
            }
            else Console.WriteLine("One or more of the specified file(s) do not exist");
        }
    }
}

