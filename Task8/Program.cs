namespace Task8
{
    class Program
    {
        private static int[,] trees;
        private static bool[,] visibility;
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
            visibility = new bool[rows.Length,rows[0].Length];
            for (int i = 1; i < Program.rows-1; i++)
            {
                for (int j = 1; j < Program.columns-1; j++)
                {
                    visibleWithinRow(i,j);
                    visibleWithinColumn(i, j);
                }
            }

            int visibleTrees = 0;
            for (int i = 1; i < Program.rows-1; i++)
            {
                for (int j = 1; j < Program.columns-1; j++)
                {
                    if (visibility[i,j])
                    {
                        visibleTrees++;
                    }
                }
            }
            Console.WriteLine(visibleTrees);
        }

        static void visibleWithinRow(int row, int column)
        {
            for (int i = 0; i < column; i++)
            {
                if (trees[row,i] > trees[row,column])
                {
                    return;
                }
            }

            for (int i = column+1; i < columns; i++)
            {
                if (trees[row,i] > trees[row,column])
                {
                    return;
                }
            }
            visibility[row, column] = true;
        }
        
        static void visibleWithinColumn(int row, int column)
        {
            for (int i = 0; i < row; i++)
            {
                if (trees[i,column] > trees[row,column])
                {
                    return;
                }
            }

            for (int i = column+1; i < rows; i++)
            {
                if (trees[i,column] > trees[row,column])
                {
                    return;
                }
            }
            visibility[row, column] = true;
        }
    }
}