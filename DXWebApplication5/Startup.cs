﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(DXWebApplication5.Startup))]

// Files related to ASP.NET Identity duplicate the Microsoft ASP.NET Identity file structure and contain initial Microsoft comments.

namespace DXWebApplication5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}