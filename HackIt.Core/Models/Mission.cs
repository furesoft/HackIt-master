﻿using System;

namespace HackIt.Core.Models
{
    public class Mission
    {
        public string Title { get; set; }
        public string[] UsableTools { get; set; }
        public Computer Host { get; set; } = new Computer();
        public Message Message { get; set; } = new Message();
        public int AvalablePoints { get; set; }
        public FileSystem Filesystem { get; set; } = new FileSystem();
        public bool ToolsAsDialog { get; set; }

        public static Mission Create(string title, int maxPoints, string[] tools, Computer host = null, string[] messages = null)
        {
            var ms = new Mission();

            ms.Title = title;
            ms.UsableTools = tools;
            ms.AvalablePoints = maxPoints;

            if (host == null)
            {
                ms.Host = new Computer();
                ms.Host.IP = Utils.GenerateIP((int)DateTime.Now.Ticks);
                ms.Host.FileSystem = new FileSystem();
                ms.Host.Name = "Localhost";
            }
            if(messages == null)
            {
                ms.Message = new Message();
            }

            return ms;
        }
    }
}