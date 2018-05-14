using ConsoleFramework;
using ConsoleFramework.Controls;

namespace HackIt.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            WindowsHost host = new WindowsHost();
            Window Loginwindow = (Window)ConsoleApplication.LoadFromXaml("HackIt.Console.Windows.LoginWindow.xml", null);

            var cb = Loginwindow.FindChildByName<ComboBox>("cb");
            host.ShowModal(Loginwindow);

            ConsoleApplication.Instance.Run(host);
        }
    }
}