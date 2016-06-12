using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DC_ServiceInjection.Service
{
    public class GreetingService : IGreetingService
    {

        public string Greet()
        {
            return "Hello";
        }
    }
}
