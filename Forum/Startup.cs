using Forum.Database;
using Forum.Hubs;
using Forum.Repositories;
using Forum.Repositories.Implementations;
using Forum.Services;
using Forum.Services.Implementations;
using Forum.Services.Implementatios;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Forum
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSignalR();
            services.AddDbContext<ForumDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("ForumApp"))
            );
            services.AddScoped<ITopicRepository, TopicRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IMessageService, MessageService>();
            services.AddTransient<ITopicService, TopicService>();
            services.AddSingleton<IMailService, MailService>();

            // установка конфигурации подключения
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                    options.LogoutPath = new Microsoft.AspNetCore.Http.PathString("/Account/LogOut");
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();    
            app.UseAuthorization();    

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<TopicHub>("/topichub");
                endpoints.MapHub<MessageHub>("/messagehub");

            });
        }
    }
}
