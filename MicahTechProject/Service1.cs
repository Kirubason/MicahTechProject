﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MicahTechProject
{
    [RunInstaller(true)]
    public partial class Service1 : ServiceBase
    {
        Thread FileWrite = null;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            ThreadStart obj = new ThreadStart(FileWriteFunction);
            FileWrite = new Thread(obj);
            FileWrite.Start();
        }

        public void FileWriteFunction()
        {
            while(true)
            {
                string Path = "D:\\Micah Tech\\Dot.Net\\WindowsService\\MicahTechProject\\Test\\Example.txt";
                using (StreamWriter obj = new StreamWriter(Path,true))
                {
                    obj.WriteLine("This is printing from Windows Service" + DateTime.Now);
                }
                Thread.Sleep(10000);
            }

        }

        protected override void OnStop()
        {
            FileWrite.Abort();
        }
    }
}
