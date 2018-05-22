using HackIt.Core;
using System.Windows.Forms;

namespace HackIt.Pages
{
    public partial class NetworkPage : UserControl, INavigatable
    {
        public NetworkPage()
        {
            InitializeComponent();

            ServiceLocator.Subscribe("LocaleChanged", _ =>
            {
                Title = ServiceLocator._("Network");
            });
        }

        public string Title { get; set; } = "Network";

        public void OnNavigate()
        {
            
        }
    }
}