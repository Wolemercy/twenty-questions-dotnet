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
    }
}

