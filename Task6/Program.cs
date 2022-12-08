namespace Task6
{
    class Program
    {
        static void Main()
        {
            string input = File.ReadAllLines("input.txt")[0];
            for (int i = 0; i < input.Length-14; i++)
            {
                string part = input.Substring(i, 14);
                if (!doesPartHaveRepeat(part))
                {
                    Console.WriteLine(i+14);
                    break;
                }
            }
        }

        private static bool doesPartHaveRepeat(string part)
        {
            for (int i = 0; i < part.Length-1; i++)
            {
                if (part.Substring(i+1).Contains(part[i]))
                {
                    return true;
                }
            }

            return false;
        }
    }
}

