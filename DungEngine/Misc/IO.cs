namespace DungEngine.Misc
{
    public static class IO
    {
        public static string[] ReadFile(string path)
        {
            List<string> content = [];
            using var sr = new StreamReader(path);

            while (!sr.EndOfStream)
            {
                string? line = sr.ReadLine();
                if (line == null)
                { continue; }

                content.Add(line);
            }

            return [.. content];
        }

        public static void WriteFile(string path, string[] content, bool append = false)
        {
            using var sw = new StreamWriter(path, append);
            foreach (string line in content)
            { sw.WriteLine(line); }
        }
    }
}