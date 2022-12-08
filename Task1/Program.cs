namespace Task1
{
    class Program
    {
        static void Main()
        {
            List<string> radky = File.ReadAllLines("input.txt").ToList();
            List<int> hodnoty = new List<int>();
            int sum = 0;
            foreach (var radek in radky)
            {
                if (radek == "")
                {
                    hodnoty.Add(sum);
                    sum = 0;
                    continue;
                }
                sum += int.Parse(radek);
            }

            int finalSum = hodnoty.Max();
            hodnoty.Remove(hodnoty.Max());
            finalSum += hodnoty.Max();
            hodnoty.Remove(hodnoty.Max());
            finalSum += hodnoty.Max();
            Console.WriteLine(finalSum);
        }
    }
}