using System.Text.RegularExpressions;

namespace Task5
{
    class Program
    {
        static void Main()
        {
            string[] rows = File.ReadAllLines("input.txt");
            List<Stack<char>> loading = new List<Stack<char>>();
            for (int i = 0; i < 9; i++)
            {
                loading.Add(new Stack<char>());
            }
            
            for (int i = 0; i < 8; i++)
            {
                string row = rows[i];
                for (int j = 1; j < 35; j += 4)
                {
                    if (row[j] == ' ')
                    {
                        continue;
                    }
                    loading[j / 4].Push(row[j]);
                }
            }
            for (int i = 0; i < 9; i++)
            {
                Stack<char> reverse = new Stack<char>();
                int topop = loading[i].Count;
                for (int j = 0; j < topop; j++)
                {
                    reverse.Push(loading[i].Pop());
                }

                loading[i] = reverse;
            }

            Regex regex = new Regex(@"\d+");
            for (int i = 10; i < rows.Length; i++)
            {
                MatchCollection match = regex.Matches(rows[i]);
                Stack<char> storage = new Stack<char>();
                for (int j = 0;j < int.Parse(match[0].Value); j++)
                {
                    storage.Push(loading[int.Parse(match[1].Value) - 1].Pop());
                }
                for (int j = 0;j < int.Parse(match[0].Value); j++)
                {
                    loading[int.Parse(match[2].Value) - 1].Push(storage.Pop());
                }
            }

            foreach (var stack in loading)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}

