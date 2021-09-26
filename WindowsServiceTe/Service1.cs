using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceTe
{
    public partial class WindowsServiceTe : ServiceBase
    {
        public WindowsServiceTe()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            System.IO.File.WriteAllText("C:\\hi.txt", "helloworld");
        }

        protected override void OnStop()
        {
        }
    }
}
