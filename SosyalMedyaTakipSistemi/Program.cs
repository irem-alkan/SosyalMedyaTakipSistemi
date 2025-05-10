var builder = WebApplication.CreateBuilder(args);

// MVC servisleri
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Hata sayfas� hari� hi�bir HTTPS y�nlendirme veya HSTS yok
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    
}

// HTTPS y�nlendirme
// app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
