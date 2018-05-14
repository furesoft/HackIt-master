﻿using System.Net;

namespace HackIt.Core.Models
{
    public class Computer
    {
        public string Name { get; set; } = "Localhost";
        public string IP { get; set; } = "";
        public Credential Credentials { get; set; }

        public FileSystem FileSystem { get; set; } = new FileSystem();
    }
}