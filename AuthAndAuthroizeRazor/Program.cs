using Microsoft.AspNetCore.Authentication.Cookies;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


      
        // Add services to the container.
        builder.Services.AddRazorPages();
          builder.Services.AddAuthentication(cfg=>{
             cfg.DefaultAuthenticateScheme=CookieAuthenticationDefaults.AuthenticationScheme;
            cfg.DefaultSignInScheme=CookieAuthenticationDefaults.AuthenticationScheme;
            cfg.DefaultChallengeScheme=CookieAuthenticationDefaults.AuthenticationScheme;
          })
          .AddCookie(options =>
        {
            options.Cookie.Name = "MyCookieAuth";
        });

        



        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
 
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}