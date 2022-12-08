namespace Task2
{
    class Program
    {
        static void Main()
        {
            List<string> rows = File.ReadAllLines("input.txt").ToList();
            int score = 0;
            foreach (var row in rows)
            {
                score += EvalGame(row);
            }

            Console.WriteLine(score);
        }

        private static int EvalGame(string row)
        {
            switch (row[0])
            {
                case 'A':
                    return EvalRock(row[2]);
                case 'B':
                    return EvalPaper(row[2]);
                case 'C':
                    return EvalScissors(row[2]);
            }

            return -1;
        }

        private static int EvalRock(char c)
        {
            switch (c)
            {
                case 'X':
                    return 3 + 0;
                case 'Y':
                    return 1 + 3;
                case 'Z':
                    return 2 + 6;
            }

            return -1;
        }
        
        private static int EvalPaper(char c)
        {
            switch (c)
            {
                case 'X':
                    return 1 + 0;
                case 'Y':
                    return 2 + 3;
                case 'Z':
                    return 3 + 6;
            }

            return -1;
        }
        
        private static int EvalScissors(char c)
        {
            switch (c)
            {
                case 'X':
                    return 2 + 0;
                case 'Y':
                    return 3 + 3;
                case 'Z':
                    return 1 + 6;
            }

            return -1;
        }
    }
}

