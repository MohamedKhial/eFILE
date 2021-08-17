using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eFileApp
{
  public  class HierarchicalItem
    {
        public string Name;
        public int Deepth;

        public HierarchicalItem(string name, int deepth)
        {
            this.Name = name;
            this.Deepth = deepth;
        }
      
    }

  public  class tree
    {

        public IEnumerable<HierarchicalItem> SearchDirectory(DirectoryInfo directory, int deep = 0)
        {
            yield return new HierarchicalItem(directory.Name, deep);

            foreach (var subdirectory in directory.GetDirectories())
                foreach (var item in SearchDirectory(subdirectory, deep + 1))
                    yield return item;

            foreach (var file in directory.GetFiles("*.png"))
                yield return new HierarchicalItem(file.Name, deep + 1);
        }
        public string ScanFolder(DirectoryInfo directory, string indentation = "\t", int maxLevel = -1, int deep = 0)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine(string.Concat(Enumerable.Repeat(indentation, deep)) + directory.Name);

            if (maxLevel == -1 || maxLevel < deep)
            {
                foreach (var subdirectory in directory.GetDirectories())
                    builder.Append(ScanFolder(subdirectory, indentation, maxLevel, deep + 1));
            }

            foreach (var file in directory.GetFiles())
                builder.AppendLine(string.Concat(Enumerable.Repeat(indentation, deep + 1)) + file.Name);

            return builder.ToString();
        }
        public List<String> DirSearch(string sDir)
        {
            List<String> files = new List<String>();
            try
            {
                foreach (string f in Directory.GetFiles(sDir))
                {
                    files.Add(f);
                }
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    files.AddRange(DirSearch(d));
                }
            }
            catch (System.Exception excpt)
            {
                MessageBox.Show(excpt.Message);
            }

            return files;
        }
    }

    
}
