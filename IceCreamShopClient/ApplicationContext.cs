using Default;
using Microsoft.Extensions.Configuration;
using System;

namespace IceCreamShopClient
{
    public class ApplicationContext : Container
    {
        public ApplicationContext(IConfiguration configuration) : base(new Uri(configuration["URL"])) { }
    }
}
