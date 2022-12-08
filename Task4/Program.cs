namespace Task4
{
    class Range
    {
        public Range(string range)
        {
            string[] split = range.Split('-');
            Lower = int.Parse(split[0]);
            Upper = int.Parse(split[1]);
        }

        public int Lower { get; }
        public int Upper { get; }

        public int Size()
        {
            return Upper - Lower;
        }
        
        public static bool operator <(Range lhs, Range rhs)
        {
            return (lhs.Upper - lhs.Lower) < (rhs.Upper - rhs.Lower);
        }

        public static bool operator >(Range lhs, Range rhs)
        {
            return (lhs.Upper - lhs.Lower) > (rhs.Upper - rhs.Lower);
        }
    }
    class Program
    {
        static void Main()
        {
            string[] rows = File.ReadAllLines("input.txt");
            int overlaps = 0;
            foreach (var row in rows)
            {
                string[] texranges = row.Split(',');
                Range range1 = new Range(texranges[0]);
                Range range2 = new Range(texranges[1]);
                if (range2.Lower <= range1.Upper && range1.Lower <= range2.Upper)
                {
                    overlaps++;
                }
                

            }

            Console.WriteLine(overlaps);
        }
    }
}

