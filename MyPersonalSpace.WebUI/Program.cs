using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MyPersonalSpace.DataAccess.Concrete;
using Minio;

var builder = WebApplication.CreateBuilder(args);

//JWT Authentication Ayarları
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
}).AddCookie(options =>
{
    options.Cookie.Name = "MyPersonalSpace";
    options.Cookie.HttpOnly = true; // Güvenlik için sadece HTTP üzerinden erişilebilir
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Sadece HTTPS üzerinden erişilebilir
    options.Cookie.SameSite = SameSiteMode.Strict; // CSRF koruması için SameSite modunu ayarla
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60); // Cookie'nin geçerlilik süresi
    options.SlidingExpiration = true; // Kullanıcı aktif kaldıkça süreyi yenile
    options.LoginPath = "/Login/Index"; // Giriş sayfası yolu
    options.LogoutPath = "/Logout/Index"; // Çıkış sayfası yolu
    options.AccessDeniedPath = "/Account/AccessDenied"; // Yetki reddedildiği durumda yönlendirme
});

// MinIO istemcisini özelleştirilmiş bir endpoint ile ekleyerek varsayılan MinioClient yapılandırmasını oluştur
builder.Services.AddMinio(configureClient => configureClient
    .WithEndpoint("localhost:9005")  // MinIO sunucusunun adresini belirtiyoruz.
    .WithCredentials("7CPs8h0IplvPAp6WLXbc", "OKyAgmJfTsOAS4HrEshkTi3V6ACmN3o6y6zpk8A1") // Erişim kimlik bilgileri
    .WithSSL(false) // SSL kullanımı devre dışı bırakılıyor (HTTP üzerinden çalıştırılıyor)
    .Build());
// Add services to the container.
builder.Services.AddDbContext<Context>();
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();


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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");
app.Run();

