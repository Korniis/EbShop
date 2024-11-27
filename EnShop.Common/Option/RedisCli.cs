using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnShop.Common.Option
{
    public sealed class RedisCli : IConfigurableOptions
    {
        public string Enable { get; set; }
        public string ConnectionString { get; set; }
        public string InstanceName { get; set; }

    }
}
