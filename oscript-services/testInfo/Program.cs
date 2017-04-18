using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace testInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProcessStartInfo startInfo = new ProcessStartInfo("postgresql-x64-9.6");
            //var srv1 = new oscript_services.Services();
            //var srvList = srv1.GetList();
            ServiceController _service = new ServiceController("postgresql-x64-9.6");
            _service.Start();
        }
    }
}
