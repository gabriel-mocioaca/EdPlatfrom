using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EdPlatform.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EdPlatform.ApplicationLogic.Data;
using EdPlatform.ApplicationLogic.Abstractions;
using EdPlatform.EFDataAccess.Repositories;
using EdPlatform.ApplicationLogic.Services;
using EdPlatform.EFDataAccess;

namespace EdPlatform
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    private async Task CreateUserRoles(IServiceProvider serviceProvider)
    {
      var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
      var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

      IdentityResult roleResult;
      //Adding Admin Role
      var roleCheck = await RoleManager.RoleExistsAsync("Admin");
      if (!roleCheck)
      {
        //create the roles and seed them to the database
        roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));

      }
      //Assign Admin role to the main User here we have given our newly registered 
      //login id for Admin management
      ApplicationUser user = await UserManager.FindByEmailAsync("andrew@admin.com");
      var User = new ApplicationUser();
      await UserManager.AddToRoleAsync(user, "Admin");


      roleCheck = await RoleManager.RoleExistsAsync("Client");
      if (!roleCheck)
      {
        //create the roles and seed them to the database
        roleResult = await RoleManager.CreateAsync(new IdentityRole("Client"));
      }

      ApplicationUser user2 = await UserManager.FindByEmailAsync("dana@petrescu.com");


      await UserManager.AddToRoleAsync(user2, "Client");
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.Configure<CookiePolicyOptions>(options =>
      {
              // This lambda determines whether user consent for non-essential cookies is needed for a given request.
              options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = SameSiteMode.None;
      });

      services.AddDbContext<ApplicationDbContext>(options =>
          options.UseSqlServer(
              Configuration.GetConnectionString("DefaultConnection")));
      services.AddDbContext<EdPlatformDbContext>(options =>
          options.UseSqlServer(
              Configuration.GetConnectionString("DefaultConnection")));
      services.AddDefaultIdentity<IdentityUser>()
          .AddEntityFrameworkStores<ApplicationDbContext>();


      services.AddScoped<IClassroomRepository, ClassroomRepository>();
      services.AddScoped<IAssignmentRepository, AssignmentRepository>();
      services.AddScoped<IMessageRepository, MessageRepository>();
      services.AddScoped<IStudentRepository, StudentRepository>();

      services.AddScoped<ClassroomService>();
      services.AddScoped<MessageService>();

      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider services)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseDatabaseErrorPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseCookiePolicy();

      app.UseAuthentication();

      app.UseMvc(routes =>
      {
        routes.MapRoute(
                  name: "default",
                  template: "{controller=Home}/{action=Index}/{id?}");
      });


      // CreateUserRoles(services).Wait();
    }
  }
}
