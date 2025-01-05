using community.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using community.Services;
using community.Middlewares;
using community.Dtos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration["ConnectionStrings:PostgreSQL"]!), ServiceLifetime.Transient);
builder.Services.AddCors(options =>
{
  options.AddDefaultPolicy(
    policy =>
    {
        policy
            .WithOrigins(
                "https://localhost:5124",
                "https://openvideogamedata.herokuapp.com",
                "https://www.openvideogamedata.com",
                "https://openvideogamedata.com")
            .WithMethods("PUT", "DELETE", "GET", "POST");
    });
});
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<GameService>();
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<GameListRequestService>();
builder.Services.AddSingleton<ItemService>();
builder.Services.AddSingleton<GameListService>();
builder.Services.AddSingleton<TrackerService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(options =>
{
    options.CookieManager = new ChunkingCookieManager();
    options.Cookie.HttpOnly = true;
    options.Cookie.SameSite = SameSiteMode.None;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
})
.AddGoogle(googleOptions =>
{
  googleOptions.ClientId = builder.Configuration["GoogleAuth:GoogleClientId"]!;
  googleOptions.ClientSecret = builder.Configuration["GoogleAuth:GoogleClientSecret"]!;
  googleOptions.ClaimActions.MapJsonKey("urn:google:profile", "link");
  googleOptions.ClaimActions.MapJsonKey("urn:google:image", "picture");
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddScoped<HttpClient>();

builder.Services.AddLocalization(options => { options.ResourcesPath = "Resources"; });

var app = builder.Build();

app.UseRequestLocalization(new RequestLocalizationOptions()
    .AddSupportedCultures(new[] { "en-US", "pt-BR" })
    .AddSupportedUICultures(new[] { "en-US", "pt-BR" }));

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.Use((context, next) =>
{
    context.Request.Scheme = "https";
    return next(context);
});
app.UseStaticFiles();

app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

app.UseRouting();
app.UseCors();

app.UseMiddleware<UserInfoMiddleware>();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
