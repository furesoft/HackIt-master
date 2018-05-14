using System;
using HackIt.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var fs = new FileSystem();
            fs.Mkdir("/", "bin");
            fs.MkFile("/bin", "boot.bin");

            var f = fs.Find("/bin/boot.bin");
        }
    }
}