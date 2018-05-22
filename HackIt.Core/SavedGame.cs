using HackIt.Core.Models;
using System;
using System.Collections.Generic;
using System.Xaml;

namespace HackIt.Core
{
    public class SavedGame
    {
        public List<Mission> CompletedMissions { get; set; } = new List<Mission>();
        public Mission CurrentMission { get; set; }
        public int Coins { get; set; } = 0;
        public int Id { get; set; } = 0;
        public int Points { get; set; }
        public Computer Computer { get; set; } = new Computer();

        public string Locale {
            get => _locale;
            set  {
                _locale = value;
                
            }
        }

        public Dictionary<string, List<Command>> Commands = new Dictionary<string, List<Command>>();
        private string _locale = "en";

        public static SavedGame Load()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\HackIT.saved";
            if (!System.IO.File.Exists(path)) return new SavedGame();

            return (SavedGame)XamlServices.Load(path);
        }

        public void Save()
        {
            XamlServices.Save(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\HackIT.saved", this);
        }
    }
}