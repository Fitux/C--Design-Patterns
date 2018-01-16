using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace SingleResponsabilityPrinciple
{
    public class Journal
    {
        private readonly List<string> entries = new List<string>();

        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count;
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
    }

    public class Persistence
    {
        public void SaveToFile(Journal journal, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
                File.WriteAllText(filename, journal.ToString());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var journal = new Journal();
            var persistent = new Persistence();
            var dirpath = Directory.GetCurrentDirectory();
            var filename = Path.Combine(dirpath, "journal.txt");

            journal.AddEntry("I cried today");
            journal.AddEntry("Just kidding");

            WriteLine(journal);

            persistent.SaveToFile(journal, filename, true);

            Process.Start(filename);
            return;
        }
    }
}
