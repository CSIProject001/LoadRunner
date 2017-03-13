// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Startup.cs" company="Candisyrup">
//   VirtualHeights LLC
// </copyright>
// <summary>
//   Defines the Startup type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Linq;
using System.Threading;
using CS.Models.DBModels;

namespace CS
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CS.Data;
    using CS.Data.Migrations;
    using CS.Models;
    using CS.Models.ProfileViewModels;
    using CS.Services;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<CandiContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
           
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {

                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseIdentity();

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            var serviceProvider = app.ApplicationServices.GetService<IServiceProvider>();
            CreateRolesandUsers(serviceProvider).Wait();
            
        }

        
        private async Task CreateRolesandUsers(IServiceProvider provider)
        {
            
            var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = provider.GetRequiredService<UserManager<ApplicationUser>>();
           
            

            var roles = new[] { "Admin", "Manager", "Normal" };
            IdentityResult roleResult;
            foreach (var role in roles)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
            //await roleManager.DeleteAsync(new IdentityRole("Administrator"));

            var adminUsers = new List<ApplicationUser>
                                 {
                                     new ApplicationUser
                                         {
                                             UserName = "smiyer@hotmail.com",
                                             Email = "smiyer@hotmail.com"
                                         },
                                     new ApplicationUser
                                         {
                                             UserName = "mpxwilliams@gmail.com",
                                             Email = "mpxwilliams@gmail.com"
                                         }
                                 };

            foreach (var user in adminUsers)
            {
                var t = new ApplicationUser { UserName = user.UserName, Email = user.Email };
                var u = await userManager.FindByEmailAsync(user.UserName);
                var password = "Irvine123!";
                if (u == null)
                {
                    var createuser = await userManager.CreateAsync(t, password);
                    if (createuser.Succeeded)
                    {
                        userManager.AddToRoleAsync(t, "Admin").Wait();
                    }
                }
                else
                {
                       await userManager.AddToRoleAsync(u, "Admin");
                }

                /*
                var c = new Customer {UserId = u.Id};
               
                if (cc.Customers.Any(m => m.UserId == c.UserId)) continue;
                cc.Customers.Add(c);
                cc.SaveChanges();
                */        
    }

        }
    }
}
