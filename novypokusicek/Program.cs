using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using novypokusicek;
using novypokusicek.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = false;
    options.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



using (IServiceScope scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

    
    if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
        await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

  
    if (!await roleManager.RoleExistsAsync(UserRoles.Editor))
        await roleManager.CreateAsync(new IdentityRole(UserRoles.Editor));

    if (!await roleManager.RoleExistsAsync(UserRoles.LepsiEditor))
        await roleManager.CreateAsync(new IdentityRole(UserRoles.LepsiEditor));


    IdentityUser? defaultAdminUser = await userManager.FindByEmailAsync("ja@gmail.com");

    
    if (defaultAdminUser is not null && !await userManager.IsInRoleAsync(defaultAdminUser, UserRoles.Admin))
    {
        await userManager.AddToRoleAsync(defaultAdminUser, UserRoles.Admin);
    }

   
    IdentityUser? editorUser = await userManager.FindByEmailAsync("ja3@gmail.com");

   
    if (editorUser is not null && !await userManager.IsInRoleAsync(editorUser, UserRoles.Editor))
    {
        await userManager.AddToRoleAsync(editorUser, UserRoles.Editor);
    }

    IdentityUser? lepsieditorUser = await userManager.FindByEmailAsync("ja4@gmail.com");


    if (lepsieditorUser is not null && !await userManager.IsInRoleAsync(lepsieditorUser, UserRoles.LepsiEditor))
    {
        await userManager.AddToRoleAsync(lepsieditorUser, UserRoles.LepsiEditor);
    }
}





app.Run();

