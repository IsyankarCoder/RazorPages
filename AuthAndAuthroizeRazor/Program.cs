using AuthAndAuthroizeRazor.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


      
        // Add services to the container.
        builder.Services.AddRazorPages();
          builder.Services.AddAuthentication("MyCookieAuth" 
          )
          .AddCookie("MyCookieAuth",options =>
          {
            options.LoginPath="/account/loginpage";
            options.AccessDeniedPath="/account/accessdeniedpage";
            options.Cookie.Name = "MyCookieAuth";
            options.ExpireTimeSpan = TimeSpan.FromMinutes(3);
          });

        builder.Services.AddAuthorization(options =>{
               options.AddPolicy("AdminOnly", policy=>policy.RequireClaim("Admin"));
               
               options.AddPolicy("MustBelongToHRDepartment",
               policy=>policy.RequireClaim("Department","HR")); 

               options.AddPolicy("HRManagerOnly", policy=> policy
                                                                .RequireClaim("Department","HR")
                                                                .RequireClaim("Manager")
                                                                .Requirements.Add(new HRManagerProbationRequirement(3))
                                                                ); 
                


        });

        builder.Services.AddSingleton<IAuthorizationHandler,HRManagerProbationRequirementHandler>();


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