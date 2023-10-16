using MvcDAL.Interface;
using MvcDAL.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient("",(s,o) =>
{
   var urlString= builder.Configuration.GetValue("URL", "https://localhost:7287/api/"); 
    o.BaseAddress = new Uri(urlString);
    o.DefaultRequestHeaders.Add("Accept", "application/json");
 //   o.DefaultRequestHeaders.Add("Authorization", "");
});
builder.Services.AddScoped<IClassRepository,ClassRepository>();
builder.Services.AddScoped<IStudentRepository ,StudentRepository>();


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
