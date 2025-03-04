using Microsoft.EntityFrameworkCore;
using BabelRoomWebApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.Win32;

namespace BabelRoomWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddAuthorization();
            //builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);

            //builder.Services.AddSingleton<IEmailSender, EmailSender>();

            builder.Services.AddIdentityApiEndpoints<User>()
                .AddEntityFrameworkStores<SampleDBContext>();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<SampleDBContext>(options =>
                                                          options.UseSqlServer(connectionString));


            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            //app.MapPost("/customm/register", async (UserManager<User> userManager, [FromBody] Register request) =>
            //{
            //    var newUser = new User
            //    {
            //        UserName = request.Email,
            //        Email = request.Email,
            //        Initials = request.Initial
            //    };

            //    var result = await userManager.CreateAsync(newUser, request.Password);

            //    if (!result.Succeeded)
            //    {
            //        return Results.BadRequest(result.Errors);
            //    }

            //    return Results.Ok(new { message = "Usuário registrado com sucesso!" });
            //});


            app.MapIdentityApi<User>();
            app.MapControllers();

            app.Run();
        }
    }
}