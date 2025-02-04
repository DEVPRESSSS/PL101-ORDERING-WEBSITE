using Microsoft.EntityFrameworkCore;
using ONLINE_BUSINESS_PROJECT_FOR_PL101_SUBJECT.Data;
using Microsoft.AspNetCore.Identity;
using ONLINE_BUSINESS_PROJECT_FOR_PL101_SUBJECT.Utilities;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace ONLINE_BUSINESS_PROJECT_FOR_PL101_SUBJECT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

            // builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<ApplicationDbContext>();
             builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
           
            builder.Services.AddRazorPages();
            builder.Services.AddScoped<IEmailSender, EmailSender>(); 
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
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
            app.MapRazorPages();
            app.MapControllerRoute(
                name: "default",
                pattern: "{area=customer}/{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
