using RWSServiceRuntime;
using System;

namespace ManageClassDomainServer
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            new DomainHost().Run(args);
        }
    }
}
