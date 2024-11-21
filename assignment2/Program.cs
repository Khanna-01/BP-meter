using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using assignment1.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BPMeasureContext>(options =>
    options.UseSqlite("Data Source=BPMeasurementsLkhanna5070.db"));
    

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
using (var scope = app.Services.CreateScope()){
    var dbcontext = scope.ServiceProvider.GetRequiredService<BPMeasureContext>();
   dbcontext.Database.Migrate();
    dbcontext.Seed();
} 


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=BPMeasure}/{action=Index}/{id?}");

app.Run();
