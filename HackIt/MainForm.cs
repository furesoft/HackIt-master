using HackIt.Core;
using HackIt.Pages;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HackIt
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            NavigationService.Container = pageContainer;

            // make form dragable
            var drag = DragableBehavior.Create(titleBar, this);
            drag.EnableDrag();

            ServiceLocator.LoadLocale();

            var links = NavigationService.CreateLinks(typeof(Program).Assembly,
                (_) =>
                {
                    _.ForeColor = Color.FromArgb(0, 192, 0);
                    _.LinkColor = Color.FromArgb(0, 192, 0);
                    _.VisitedLinkColor = Color.FromArgb(0, 192, 0);
                });


            flowLayoutPanel1.Controls.AddRange(links);

            var ip = Utils.GenerateIP(Environment.TickCount);
            var pc = ServiceLocator.Get<SavedGame>("SavedGame").Computer;

            var ipfind = new IPFinder(pc, ipLabel);
            ipfind.StartFinding();

            pc.IP = ip;
            pc.Name = "Localhost";


            ServiceLocator.Subscribe("Loaded", _ => {
                yourIPLabel.Text = ServiceLocator._("Your IP:") + ServiceLocator.Get<SavedGame>("SavedGame").Computer.IP;
            });

            yourIPLabel.Text = ServiceLocator._("Your IP:") + ip;

            NavigationService.Navigate(new WelcomePage());
        }

        private void closeBtn_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }
    }
}