﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vidly.Startup))]

namespace Vidly
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            ConfigureAuth(app);
        }
    }
}
