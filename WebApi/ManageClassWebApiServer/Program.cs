using System;
using WebApiCommon;

namespace ManageClassWebApiServer
{
    class Program
    {
        static void Main(string[] args)
        {
            new MyWebHost<Startup>().Run(args);
        }
    }
}
