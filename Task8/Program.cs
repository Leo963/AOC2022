namespace Task8
{
    class Program
    {
        private static int[,] trees;
        private static int[,] scores;
        private static int rows, columns;
        static void Main()
        {
            string[] rows = File.ReadAllLines("input.txt");
            Program.rows = rows.Length;
            Program.columns = rows[0].Length;
            trees = new int[rows.Length,rows[0].Length];
            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = 0; j < rows[i].Length; j++)
                {
                    trees[i, j] = rows[i][j] - '0';
                }
            }
            scores = new int[rows.Length,rows[0].Length];
            for (int i = 0; i < Program.rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i == 0 || j == 0 || i == Program.rows-1 || j == columns-1)
                    {
                        scores[i, j] = 0;
                    }
                    else
                    {
                        scores[i, j] = CalculateScore(i, j);
                    }
                }
            }

            List<int> listScores = new List<int>();
            int enter = 0;
            Console.Write($"|");
            foreach (var score in scores)
            {
                Console.Write($"{score}|");
                enter++;
                if (enter % columns == 0)
                {
                    Console.WriteLine();
                    Console.Write($"|");
                }
                listScores.Add(score);
            }

            Console.WriteLine(listScores.Max());
        }

        private static int CalculateScore(int i, int j)
        {
            return CalculateUp(i, j) * CalculateDown(i, j) * CalculateLeft(i, j) * CalculateRight(i, j);
        }

        private static int CalculateRight(int i, int j)
        {
            int score = 0;
            int iter = j + 1;
            while (iter < columns && trees[i,iter] < trees[i,j])
            {
                score++;
                iter++;
            }

            return score;
        }

        private static int CalculateLeft(int i, int j)
        {
            int score = 1;
            int iter = j - 1;
            while (iter > 0 && trees[i,iter] < trees[i,j])
            {
                score++;
                iter--;
            }

            return score;
        }

        private static int CalculateDown(int i, int j)
        {
            int score = 1;
            int iter = i + 1;
            while (iter < rows && trees[iter,j] < trees[i,j])
            {
                score++;
                iter++;
            }

            return score;
        }

        private static int CalculateUp(int i, int j)
        {
            int score = 1;
            int iter = i - 1;
            while (iter > 0 && trees[iter,j] < trees[i,j])
            {
                score++;
                iter--;
            }

            return score;
        }
    }
}