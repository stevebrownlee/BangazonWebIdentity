using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bangazon.Services
{
    public interface IApplicationConfiguration
    {
        string MovieAPIKey { get; set; }
    }
}
