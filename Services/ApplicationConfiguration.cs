using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bangazon.Services
{
    public class ApplicationConfiguration: IApplicationConfiguration
    {
        public string MovieAPIKey { get; set; }

    }
}
