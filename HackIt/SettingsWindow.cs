using HackIt.Core;

namespace HackIt
{
    public partial class SettingsWindow : DialogForm
    {
        public SettingsWindow()
        {
            InitializeComponent();

            ServiceLocator.Subscribe("LocaleChanged", _ =>
            {
                Title = ServiceLocator._("Settings");
            });
        }
    }
}