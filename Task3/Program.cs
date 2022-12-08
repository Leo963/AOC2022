namespace Task3
{
    class Program
    {
        static void Main()
        {
            Part1();
            Part2();
        }

        private static void Part2()
        {
            List<string> rows = File.ReadAllLines("input.txt").ToList();
            int totalPriority = 0;
            for (int i = 0; i < rows.Count; i += 3)
            {
                totalPriority += EvaluateGroups(rows[i], rows[i + 1], rows[i + 2]);
            }

            Console.WriteLine(totalPriority);
        }

        private static int EvaluateGroups(string row, string row1, string row2)
        {
            foreach (var character in row)
            {
                if (row1.Contains(character) && row2.Contains(character))
                {
                    if (Char.IsLower(character))
                    {
                        return (int)character - 96;                        
                    }
                    return ((int)character - 64) + 26;
                }
            }

            return -1;
        }

        static void Part1()
        {
            List<string> rows = File.ReadAllLines("input.txt").ToList();
            int totalPriority = 0;
            foreach (var row in rows)
            {
                totalPriority += EvaluateRow(row);
            }

            Console.WriteLine(totalPriority);
        }

        private static int EvaluateRow(string row)
        {
            string firstHalf = row.Substring(0,row.Length/2);
            string secondHalf = row.Substring(row.Length/2,row.Length/2);;
            foreach (var character in firstHalf)
            {
                if (secondHalf.Contains(character))
                {
                    if (Char.IsLower(character))
                    {
                        return (int)character - 96;                        
                    }
                    return ((int)character - 64) + 26;
                    break;
                }
            }
            return 0;
        }
    }
}

