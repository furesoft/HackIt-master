using HackIt.Core.Models;
using System.Collections.Generic;
using System.Xaml;

namespace HackIt.Core
{
    public class MissionPack : List<Mission>
    {
        public string Name { get; set; }
        
        public static MissionPack Load(string filename)
        {
            return (MissionPack)XamlServices.Load(filename);
        }

        public void Save(string filename)
        {
            System.IO.File.Delete(filename);

            var content = System.Xaml.XamlServices.Save(this);
            System.IO.File.WriteAllText(filename, content);
        }

        public override string ToString() => Name;
    }
}