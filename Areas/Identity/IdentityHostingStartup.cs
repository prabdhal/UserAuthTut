using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserAuthTut.Areas.Identity.Data;
using UserAuthTut.Data;

[assembly: HostingStartup(typeof(UserAuthTut.Areas.Identity.IdentityHostingStartup))]
namespace UserAuthTut.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<UserAuthDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("UserAuthDbContextConnection")));

                // To remove email confirmation we set RequiredConfirmedAccount = false
                services.AddDefaultIdentity<UserApplication>(options =>
                {
                options.SignIn.RequireConfirmedAccount = false;
                // To disable the following validation
                //options.Password.RequireLowercase = false; 
                //options.Password.RequireLowercase = false;
                })
                    .AddEntityFrameworkStores<UserAuthDbContext>();
            });
        }
    }
}