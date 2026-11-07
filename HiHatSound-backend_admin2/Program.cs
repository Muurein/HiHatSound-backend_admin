using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HiHatSound_backend_admin2.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false) //ändra asenare till true?
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Angular", policy =>
    {
        policy
            .WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//aktiverar CORS
// app.UseCors(builder => builder //ÄNDRA VID PUBLICERING TILL WITHORIGINS("DOMÄN)
//     .AllowAnyOrigin()
//     .AllowAnyMethod()
//     .AllowAnyHeader());


app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("Angular");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
