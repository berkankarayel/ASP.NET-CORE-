var builder = WebApplication.CreateBuilder(args);

// 1️⃣ MVC servislerini ekliyoruz
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 2️⃣ Ortam kontrolü (dev/prod)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// 3️⃣ Middleware pipeline
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// 4️⃣ Varsayılan route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

