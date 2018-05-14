﻿using HackIt.Core;
using HackIt.Core.Models;
using MissionBuilder.Pages;
using System;
using System.Windows.Forms;

namespace MissionBuilder
{
    public partial class MainForm : Form
    {
        MissionPack mp;
        Mission currentMission;

        public MainForm()
        {
            InitializeComponent();

            NavigationService.Container = pageContainer;
            mp = ServiceLocator.Get<MissionPack>("MissionPack");

            if (mp.Count > 0)
            {
                missionAuswählenToolStripMenuItem_Click(null, EventArgs.Empty);
                NavigationService.Navigate(new GeneralPage());
            }
        }

        private void beendenToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void ladenToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                mp = MissionPack.Load(openFileDialog1.FileName);

                ServiceLocator.Add("MissionPack", mp);
                ServiceLocator.Add("filename", openFileDialog1.FileName);
            }
        }

        private void neueMissionToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            currentMission = new Mission();
            ServiceLocator.Add("CurrentMission", currentMission);
            mp.Add(currentMission);

            NavigationService.Navigate(new GeneralPage());
        }

        private void speichernToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            mp.Save(ServiceLocator.Get<string>("filename"));
        }

        private void missionAuswählenToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var selectMission = new MissionSelector(mp);
            if(selectMission.ShowDialog() == DialogResult.OK)
            {
                currentMission = selectMission.Mission;
                ServiceLocator.Add("CurrentMission", currentMission);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NavigationService.Navigate(new GeneralPage());
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NavigationService.Navigate(new FilesystemPage());
        }
    }
}