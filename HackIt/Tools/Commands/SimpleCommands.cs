using HackIt.Core;
using System.Drawing;
using System.Windows.Forms;
using UILibrary;
using HackIt.Pages;
using System.Globalization;

namespace HackIt.Tools.Commands
{
    public class SimpleCommands : ITool
    {
        public string HelpText => "save|load|echo <text in qotes>|cls|shutdown|info|settings <key> <value>";

        public string Name { get; set; } = "*";
        public bool UseRegex { get; set; } = false;

        public void HandleConsole(ShellControl shell, Command cmd)
        {
            switch (cmd.Name)
            {
                case "help":
                    Shell.WriteLine("Here are some Commands");
                    foreach (var c in ConsolePage.Tools)
                    {
                        var spl = c.HelpText.Split('|');
                        foreach (var ht in spl)
                        {
                            Shell.WriteLine(ht);
                        }
                    }

                    break;
                case "save":
                    var sg = ServiceLocator.Get<SavedGame>("SavedGame");
                    sg.Save();

                    Shell.WriteLine("Successfully saved");

                    break;
                case "load":
                    var sg2 = ServiceLocator.Add("SavedGame", SavedGame.Load());
                    ServiceLocator.CallEvent("Loaded", sg2);

                    Shell.WriteLine("Successfully loaded");

                    break;
                case "echo":
                    Shell.WriteLine(cmd.Args[0]);

                    break;
                case "cls":
                    Shell.Clear();

                    break;
                case "shutdown":
                    Application.Exit();

                    break;
                case "info":
                    Shell.WriteLine(ServiceLocator._("Name:") + " " + ServiceLocator.Get<SavedGame>("SavedGame").Computer.Name);
                    Shell.WriteLine(ServiceLocator._("Language:") + " " + ServiceLocator.Get<SavedGame>("SavedGame").Locale);
                    break;
                case "settings":
                    switch (cmd.Args[0])
                    {
                        case "language":
                            var sg3 = ServiceLocator.Get<SavedGame>("SavedGame");
                            
                            sg3.Locale = cmd.Args[1];
                            CultureInfo.CurrentUICulture = new CultureInfo(sg3.Locale);

                            ServiceLocator.LoadLocale();
                            

                            break;
                        default:
                            break;
                    }

                    break;
            }
        }

        public bool ShowDialog() => false;
    }
}