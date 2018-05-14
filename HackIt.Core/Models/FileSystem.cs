using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HackIt.Core.Models
{
    public class FileSystem
    {
        public Directory Root { get; set; } = new Directory() { Name = "" };

        public NameBase Find(string query)
        {
            var spl = query.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            NameBase current = null;

            if (spl.Length == 0) return Root;

            foreach (var q in spl)
            {
                if (spl.Length == 1)
                {
                    current = Root;
                }


                var dirs = current as Directory;

                if (dirs != null)
                {
                    foreach (var item in ((Directory)current).Items)
                    {
                        if (item.Name == q)
                        {
                            current = item;
                        }
                    }
                }

                if (current == null) throw new System.IO.DirectoryNotFoundException(q + " not found");
            }

            //if (current == Root) throw new System.IO.FileNotFoundException(spl.Last() + " not found");

            return current;
        }

        public FileSystem Mkdir(string path, string name)
        {
            var dir = new Directory();
            dir.Name = name;

            var p = Find(path) as Directory;
            dir.Parent = p;
            if (p != null)
            {
                p.Items.Add(dir);
            }

            return this;
        }
        public FileSystem MkFile(string path, string name)
        {
            var file = new File();
            file.Name = name;

            var p = Find(path) as Directory;
            if (p != null)
            {
                p.Items.Add(p);
            }

            return this;
        }
    }

    public class Directory : NameBase
    {
        public List<NameBase> Items { get; set; } = new List<NameBase>();
    }
    public class File : NameBase
    {

    }
    public class NameBase
    {
        public string Name { get; set; }
        public NameBase Parent { get; set; }
    }
}