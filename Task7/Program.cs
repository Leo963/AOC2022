using System.Text.RegularExpressions;

namespace Task7
{
    interface IFolderElement
    {
        
    }
    class File : IFolderElement
    {
        public int Size { get; }
        public string Name { get; }

        public File(int size, string name)
        {
            Size = size;
            Name = name;
        }
    }

    class Folder : IFolderElement
    {
        public string Name { get; }
        public List<IFolderElement> Files { get; }
        public Folder Parent { get; set; }

        public Folder(string name)
        {
            this.Name = name;
            this.Files = new List<IFolderElement>();
        }

        public bool HasSubFolder()
        {
            return GetAllSubfolders().Count > 0 ? true : false;
        }
        public List<Folder> GetAllSubfolders()
        {
            return Files.Where(x => x.GetType() == typeof(Folder)).Select(x => (Folder)x).ToList();
        }
        
        public List<File> GetAllFiles()
        {
            return Files.Where(x => x.GetType() == typeof(File)).Select(x => (File)x).ToList();
        }

        public int GetSizeOfFolder()
        {
            int sum = GetAllFiles().Sum(x => x.Size);
            sum += GetAllSubfolders().Sum(x => x.GetSizeOfFolder());
            return sum;
        }

        public string GetFullPath()
        {
            if (Parent is null)
            {
                return Name;
            }
            else
            {
                return Parent.GetFullPath() + "/" + Name;
            }
        }
    }
    class Program
    {
        private static readonly Regex command = new (@"\$ ([a-z]{2}) ?([a-z\/.]*)");
        private static readonly Regex listLine = new (@"(dir|\d+) ([a-z.]*)");
        private static string[] rows;
        private static Dictionary<string,int> sizes = new Dictionary<string, int>();
        static void Main()
        {
            
            rows = System.IO.File.ReadAllLines("input.txt");
            Folder currentFolder = new Folder("/");
            Folder root = currentFolder;
            for (int i = 1; i < rows.Length; i++)
            {
                if (command.IsMatch(rows[i]))
                {
                    switch (command.Match(rows[i]).Groups[1].Value)
                    {
                        case "cd":
                            if (command.Match(rows[i]).Groups[2].Value == "..")
                            {
                                currentFolder = currentFolder.Parent;
                            }
                            else
                            {
                                currentFolder = (Folder) currentFolder.GetAllSubfolders()
                                    .Find(x => x.Name == command.Match(rows[i]).Groups[2].Value);
                            }
                            break;
                        case "ls":
                            i++;
                            i = ProcessLS(currentFolder, i);
                            break;
                    }
                }
            }

            Stack<Folder> toEval = new Stack<Folder>();
            toEval.Push(root);
            while (toEval.Count != 0)
            {
                Folder current = toEval.Pop();
                sizes.Add(current.GetFullPath(),current.GetSizeOfFolder());
                foreach (var folder in current.GetAllSubfolders())
                {
                    toEval.Push(folder);
                }
            }
            
            Console.WriteLine("Sum of folders under 100000:" + sizes.Where(x => x.Value <= 100000).Sum(x => x.Value));
            Console.WriteLine("Total size of root:" + root.GetSizeOfFolder());
            Console.WriteLine("Need to delete:" + (30000000 - (70000000-root.GetSizeOfFolder())));
            Console.WriteLine("Delte folder at path: " + 
                              sizes.Where(x => x.Value > (30000000 - (70000000-root.GetSizeOfFolder())))
                                  .Min(x => x.Value)
                              );
        }

        private static int ProcessLS(Folder currentFolder, int i)
        {
            while (i < rows.Length && listLine.IsMatch(rows[i]))
            {
                if (listLine.Match(rows[i]).Groups[1].Value == "dir")
                {
                    Folder subFolder = new Folder(listLine.Match(rows[i]).Groups[2].Value);
                    subFolder.Parent = currentFolder;
                    currentFolder.Files.Add(subFolder);
                }
                else
                {
                    
                    currentFolder.Files.Add(new File(int.Parse(listLine.Match(rows[i]).Groups[1].Value),listLine.Match(rows[i]).Groups[2].Value));
                }
                i++;
            }

            i--;
            return i;
        }
    }
}
