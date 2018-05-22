using HackIt.Core;

namespace HackIt.Tools.Dialogs
{
    public partial class PingDialog : DialogForm
    {
        public PingDialog()
        {
            InitializeComponent();

            ServiceLocator.Subscribe("LocaleChanged", _ =>
            {
                Title = ServiceLocator._("Ping");

            });
        }
    }
}