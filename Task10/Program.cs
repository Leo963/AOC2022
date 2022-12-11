namespace Task10
{
    class Program
    {
        public static void RenderValue(int value, int i)
        {
            if (value >= (i % 40)-1 && value <= (i % 40)+1)
            {
                Console.Write("#");
            }
            else
            {
                Console.Write(".");
            }

            if (i % 40 == 0)
            {
                Console.WriteLine();
            }
        }
        static void Main()
        {
            int xRegister = 1;
            int cycleCounter = 1;
            RenderValue(xRegister,cycleCounter);
            string[] rows = File.ReadAllLines("input.txt");
            List<int> strengths = new List<int>();
            foreach (var row in rows)
            {
                switch (row.Substring(0,4))
                {
                    case "noop":
                        if ((cycleCounter - 20) % 40 == 0)
                        {
                            strengths.Add(xRegister * cycleCounter);
                        }
                        cycleCounter++;
                        RenderValue(xRegister,cycleCounter);
                        break;
                    case "addx":
                        if ((cycleCounter - 20) % 40 == 0)
                        {
                            strengths.Add(xRegister * cycleCounter);
                        }
                        cycleCounter++;
                        RenderValue(xRegister,cycleCounter);
                        if ((cycleCounter - 20) % 40 == 0)
                        {
                            strengths.Add(xRegister * cycleCounter);
                        }
                        
                        cycleCounter++;
                        RenderValue(xRegister,cycleCounter);
                        xRegister += int.Parse(row.Substring(5));
                        break;
                }
            }

            Console.WriteLine(strengths.Sum());
        }
    }
}

