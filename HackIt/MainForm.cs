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

            var drag = DragableBehavior.Create(titleBar, this);
            drag.EnableDrag();

           
            var links = NavigationService.CreateLinks(new[] { typeof(ConsolePage), typeof(NetworkPage) },
                (_) =>
                {
                    _.ForeColor = Color.FromArgb(0, 192, 0);
                    _.LinkColor = Color.FromArgb(0, 192, 0);
                    _.VisitedLinkColor = Color.FromArgb(0, 192, 0);
                });

            flowLayoutPanel1.Controls.AddRange(links);

            ServiceLocator.Add("SavedGame", SavedGame.Load());

            var ip = Utils.GenerateIP(Environment.TickCount);
            var pc = ServiceLocator.Get<SavedGame>("SavedGame").Computer;

            pc.IP = ip;
            pc.Name = "Localhost";

            ServiceLocator.Subscribe("Loaded", _ => {
                yourIPLabel.Text = "Your IP: " + ServiceLocator.Get<SavedGame>("SavedGame").Computer.IP;
                });

            yourIPLabel.Text = "Your IP: " + ip;

            NavigationService.Navigate(new WelcomePage());
        }

        private void closeBtn_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }
    }
}