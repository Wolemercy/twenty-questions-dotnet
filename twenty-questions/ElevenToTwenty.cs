using System;
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

        public void TaxClassifier()
        {
            Console.WriteLine("Q13`: Classifying your Tax");
            Console.WriteLine("Please input how much you earn");

            int salary = Convert.ToInt32(Console.ReadLine());

            switch (salary)
            {
                case <= 0:
                    Console.WriteLine("Only positive numbers are allowed");
                    break;
                case < 50000:
                    Console.WriteLine($"Tax is 5%: {Math.Round(0.05 * salary, 2)}");
                    break;
                case < 200000:
                    Console.WriteLine($"Tax is 10%: {Math.Round(0.1 * salary)}");
                    break;
                default:
                    Console.WriteLine($"Tax is 15%: {Math.Round(0.15 * salary)}");
                    break;
            }
            return;
        }

        public void NumberInWords()
        {
            // Based off: http://www.blackwasp.co.uk/NumberToWords.aspx
            Console.WriteLine("Q14: Number in Words");
            Console.WriteLine("Please enter the number you need transformed into words");

            int number;
            try
            {
                string userInput = Console.ReadLine();
                number = Convert.ToInt32(userInput);
                if (number < 0) throw new FormatException();
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Could not convert the input to a positive 32-bit integer");
                return;
            }

            string[] smallNumbers = new string[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"};

            string[] tensNumbers = new string[] { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

            string[] scaleNumbers = new string[] { "", "Thousand", "Million", "Billion" };

            if (number == 0)
            {
                string res = smallNumbers[0];
                Console.WriteLine(res);
                return;
            }

            int[] digitGroups = new int[4];
            for (int i = 0; i < 4; i++)
            {
                digitGroups[i] = number % 1000;
                number /= 1000;
            }

            // Converts a three-digit group into English words
            string _ThreeDigitGroupToWords(int threeDigits)
            {
                string groupText = "";

                // Determine the hundreds and tensUnits
                int hundreds = threeDigits / 100;
                int tensUnits = threeDigits % 100;

                // rule for hundreds
                if (hundreds > 0)
                {
                    groupText += smallNumbers[hundreds] + " Hundred";

                    if (tensUnits > 0)
                    {
                        groupText += " and ";
                    }
                }

                // Determine the tens and units
                int tens = tensUnits / 10;
                int units = tensUnits % 10;

                // tens and units rules
                if (tens >= 2)
                {
                    groupText += tensNumbers[tens];

                    if (units > 0)
                    {
                        groupText += " " + smallNumbers[units];
                    }
                } else if (tensUnits > 0)
                {
                    groupText += smallNumbers[tensUnits];
                }

                return groupText;
            }

            string[] groupTexts = new string[4];
            for (int i = 0; i < 4; i++)
            {
                groupTexts[i] = _ThreeDigitGroupToWords(digitGroups[i]);
            }

            // combining the digitgroups;
            string combined = groupTexts[0];
            bool appendAnd;

            appendAnd = digitGroups[0] > 0 && digitGroups[0] < 100;

            for (int i = 1; i < 4; i++)
            {
                if (digitGroups[i] > 0)
                {
                    string prefix = groupTexts[i] + " " + scaleNumbers[i];

                    if (combined.Length > 0)
                    {
                        prefix += appendAnd ? " and " : ", ";
                    }

                    appendAnd = false;

                    combined = prefix + combined;
                }
            }
            Console.WriteLine($"{combined}");
            return;
        }

        public void SimpleInterestCalculator()
        {
            Console.WriteLine("Q15: Simple Interest Calculator");
            double principal;
            double rate;
            int time;

            try
            {
                Console.WriteLine("Please input the principal:");
                principal = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Please input the rate (%): ");
                rate = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Please input the time");
                time = Convert.ToInt32(Console.ReadLine());

                if ( principal < 0 || rate < 0 || time < 0)
                {
                    throw new FormatException();
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Could not convert input into a positive value");
                return;
            }

            Console.WriteLine($"Principal: {principal}");
            Console.WriteLine($"Rate (%): {rate}");
            Console.WriteLine($"Time: {time}");

            for (int i = 1; i <= time; i++)
            {
                Console.WriteLine($"Year {i}");

                double interest = principal * rate * i * 0.01;
                principal += interest;
                Console.WriteLine("Interest: {0:C}", interest);
                Console.WriteLine("New Principal: {0:C}\n", principal);
            }

            Console.WriteLine("Final amount: {0:C}\n", principal);
            return;
        }
    }
}

