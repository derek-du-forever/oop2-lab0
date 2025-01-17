namespace Lab0
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var low = GetPositiveInt("low number");
            var high = GetHigh(low);

            int diff = high - low;
            Console.WriteLine($"Difference between {low} and {high} is {diff}");


            int[] numbers = new int[diff+1];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = low + i;
            }



            SaveNumbersToFile(numbers);

            var storedNumbers = GetNumbersFromFile(numbers.Length);
            Console.WriteLine("sum: "+ Sum(storedNumbers).ToString());


            for (int i = 0; i < storedNumbers.Count; i++)
            {
                if (IsPrime(storedNumbers[i]))
                {
                    Console.WriteLine(storedNumbers[i].ToString() + " is a prime number");
                }
            }
        }


        private static int GetPositiveInt(string prompt)
        {
            while (true)
            {
                Console.WriteLine($"Enter {prompt}:");
                if (!int.TryParse(Console.ReadLine(), out int low))
                {
                    Console.WriteLine($"Error: {prompt} must be a whole number");
                    continue;
                }
                if (low <= 0)
                {
                    Console.WriteLine($"Error: {prompt} must be positive");
                    continue;
                }

                return low;
            }

        }

        private static int GetHigh(int low)
        {
            while (true)
            {
                var high = GetPositiveInt("high number");
                if (high <= low)
                {
                    Console.WriteLine($"Error: high number must be between {low} and {int.MaxValue}");
                    continue;
                }

                return high;
            }
        }

        private static void SaveNumbersToFile(int[] numbers)
        {
            StreamWriter streamWriter = File.CreateText("numbers.txt");
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                streamWriter.WriteLine(numbers[i]);
            }
            streamWriter.Close(); // important to finalize the writing
            Console.WriteLine("File written");
        }

        private static List<double> GetNumbersFromFile(int lineCount)
        {
            var numbers = new List<double>();
            // read the numbers back from the file and print out the sum of the numbers
            StreamReader streamReader = File.OpenText("numbers.txt");
            string nextLine;
            for (int i = 0; i < lineCount; i++)
            {
                nextLine = streamReader.ReadLine() ?? "";
                numbers[i] = Convert.ToInt32(nextLine);
            }
            streamReader.Close();

            return numbers;
        }


        private static double Sum(List<double> numbers)
        {
            double sum = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }


        private static bool IsPrime(double value)
        {
            if (value <= 1)
            {
                return false;
            }

            for (int i = 2; i < value; i++)
            {
                if (value % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
