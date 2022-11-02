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

        public void ConvertToDecimal()
        {
            Console.WriteLine("Q16: Convert To Decimal");

            int baseN;
            int number;
            try
            {
                Console.WriteLine("Input the base you want to convert from: ");
                baseN = Convert.ToInt32(Console.ReadLine());
                if (baseN < 2) throw new FormatException();

                Console.WriteLine("Input the number value you want to convert: ");
                number = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Accepted bases range from 2 to {Int32.MaxValue}");
                return;
            }

            int absNumber = Math.Abs(number);
            double result = 0;

            try
            {
                int placeValue = 0;

                while (absNumber > 0)
                {
                    int quotient = absNumber / 10, remainder = absNumber % 10;
                    result += remainder * Math.Pow(baseN, placeValue);

                    placeValue++;
                    absNumber = quotient;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not convert {number} from base {baseN} to base 10");
                return;
            }

            if (number < 0) result = -result;
            Console.WriteLine($"Result: {result}");
        }

        public void ConvertDecimalToBaseN()
        {
            Console.WriteLine("Q17: Convert Decimal to Base N");

            int baseN;
            int number;
            try
            {
                Console.WriteLine("Input the base you want to convert to: ");
                baseN = Convert.ToInt32(Console.ReadLine());
                if (baseN < 2) throw new FormatException();

                Console.WriteLine("Input the number value you want to convert: ");
                number = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Accepted bases range from 2 to {Int32.MaxValue}");
                return;
            }

            int absNumber = Math.Abs(number);
            double result = 0;

            try
            {
                int placeValue = 0;

                while (absNumber > 0)
                {
                    int quotient = absNumber / baseN, remainder = absNumber % baseN;
                    result += remainder * Math.Pow(10, placeValue);

                    placeValue++;
                    absNumber = quotient;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not convert {number} from base 10 to base {baseN}");
                return;
            }

            if (number < 0) result = -result;
            Console.WriteLine($"Result: {result}");
        }

        public void CalculateCGPA(string records)
        {
            double[] _calculate(string[] scores) {
                double cgpa = 0;
                double averageScore = 0;

                for (int i = 0; i < scores.Length; i++)
                {
                    int score = Convert.ToInt32(scores[i]);
                    cgpa = ((cgpa * i) + (score / 20)) / (i + 1);
                    averageScore = ((averageScore * i) + score) / (i + 1);
                }

                return new double[] { Math.Round(cgpa, 2), Math.Round(averageScore, 2) };
            }

            Console.WriteLine("Q18: Calculating CGPAs");

            if (File.Exists(records))
            {
                using(StreamReader sr = new StreamReader(records))
                using (StreamWriter sw = new StreamWriter("cgpa.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] splitRecord = sr.ReadLine().Split(',');
                        if (splitRecord[0] == "id") continue;

                        double[] result = _calculate(splitRecord.Skip(2).Take(5).ToArray());
                        string output = $"{splitRecord[1]} ({splitRecord[0]}): {result[1]} {result[0]}";
                        sw.WriteLine(output);
                        Console.WriteLine(output);
                    }
                }
            }
            else Console.WriteLine("The specified file does not exist");
        }

        public void AttendanceRegister(string students)
        {
            Console.WriteLine("Q19: Checking Attendance");

            if (File.Exists(students))
            {
                using (StreamReader sr = new StreamReader(students))
                using (StreamWriter sw = new StreamWriter("studentsregister.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        string student = sr.ReadLine();
                        Console.WriteLine($"Is {student} in class? [yes/no]");

                        bool awaitingInput = true;
                        string inClass ="";

                        while (awaitingInput)
                        {
                            try
                            {
                                string userInput = Console.ReadLine().ToLower();
                                if (userInput == "yes") inClass =   "✅";
                                else if (userInput == "no") inClass = "❌";
                                else throw new FormatException();

                                awaitingInput = false;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Please enter either 'yes' or 'no'");
                            }
                        }

                        string result = $"{student}:\t\t{inClass}";
                        sw.WriteLine(result);
                        Console.WriteLine(result);
                        
                    }
                }
            }
            else Console.WriteLine("The specified file does not exist");
            return;
        }

        public void LoveCalculator()
        {

            string _calculate(string numString)
            {
                if (numString.Length == 2) return numString;

                string nextNumString = "";

                int left = 0;
                int right = numString.Length - 1;

                
                while (left < right)
                {
                    int leftNum = numString[left] - '0';
                    int rightNum = numString[right] - '0';
                    nextNumString += leftNum + rightNum;
                    //Console.WriteLine(nextNumString + " " + numString + "  " + left + " " + right + " " + leftNum + " " + rightNum);

                    left++;
                    right--;
                }

                if (left == right) nextNumString += numString[left];
                return _calculate(nextNumString);
            }
            Console.WriteLine("Q20: Calculating Love, I guess");

            Console.WriteLine("Input the name of the first person: ");
            string person1 = Console.ReadLine().ToLower();

            Console.WriteLine("Input the name of the second person: ");
            string person2 = Console.ReadLine().ToLower();

            string combinedResult = person1 + "loves" + person2;

            IDictionary<string, int> charFrequency = new Dictionary<string, int>();

            string numString = "";

            foreach (char c in combinedResult)
            {
                if (charFrequency.ContainsKey(c.ToString()))
                {
                    charFrequency[c.ToString()] += 1;
                } else charFrequency[c.ToString()] = 1;
            }

            foreach (char c in combinedResult)
            {
                numString += charFrequency[c.ToString()];
            }

            Console.WriteLine(numString);
            string lovePercent = _calculate(numString);
            Console.WriteLine($"The love percentage is {lovePercent}%");

        }
    }
}

