using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Feitep.Data;   // ← namespace onde está o seu ApplicationDbContext

var builder = WebApplication.CreateBuilder(args);

// Connection string do SQLite (corrigido o "Data Source" com espaço)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                       ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Identity + Entity Framework Stores
builder.Services.AddDefaultIdentity<IdentityUser>(options => 
        options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddRazorPages();

var app = builder.Build();

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();   // ← estava faltando (importante para Identity)
app.UseAuthorization();

app.MapRazorPages();

// Garante que o banco seja criado na primeira execução (super útil em desenvolvimento)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate(); // ou db.Database.EnsureCreated(); se não usar migrations
}

app.Run();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        