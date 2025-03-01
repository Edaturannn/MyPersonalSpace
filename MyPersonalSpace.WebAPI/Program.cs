using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Minio;
using MyPersonalSpace.Business.Abstract;
using MyPersonalSpace.Business.Concrete;
using MyPersonalSpace.Business.JwtServices;
using MyPersonalSpace.DataAccess.Abstract;
using MyPersonalSpace.DataAccess.Concrete;
using MyPersonalSpace.DataAccess.EntityFramework;
using MyPersonalSpace.DataAccess.Repositories;
using MyPersonalSpace.Dtos.AutoMapper;
using MyPersonalSpace.WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


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


// HttpClient ve OllamaService'i servise ekleyelim
builder.Services.AddHttpClient<OllamaService>();
builder.Services.AddScoped<OllamaService>();

builder.Services.AddDbContext<Context>();
builder.Services.AddAutoMapper(typeof(Mapping));

builder.Services.AddScoped<ICategoryDal, EFCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddScoped<ICommentDal, EFCommentDal>();
builder.Services.AddScoped<ICommentService, CommentManager>();

builder.Services.AddScoped<IPostDal, EFPostDal>();
builder.Services.AddScoped<IPostService, PostManager>();

builder.Services.AddScoped<IPostTagDal, EFPostTagDal>();
builder.Services.AddScoped<IPostTagService, PostTagManager>();

builder.Services.AddScoped<ITagDal, EFTagDal>();
builder.Services.AddScoped<ITagService, TagManager>();

builder.Services.AddScoped<IAboutDal, EFAboutDal>();
builder.Services.AddScoped<IAboutService, AboutManager>();

builder.Services.AddScoped<IContactDal, EFContactDal>();
builder.Services.AddScoped<IContactService, ContactManager>();


builder.Services.AddScoped<IUserDal, EFUserDal>();
builder.Services.AddScoped<UserManager>();

builder.Services.AddScoped<IUserService, UserManager>();

builder.Services.AddScoped<IJwtService, JwtService>();


builder.Services.AddHttpContextAccessor();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();

