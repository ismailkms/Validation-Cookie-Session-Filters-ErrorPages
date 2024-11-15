var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseExceptionHandler("/Home/Error");
//Programýn içerisinde oluþan hatalarý yakalamamýzý saðlar. Program bir hata atarsa o zaman çalýþýr.
app.UseStatusCodePagesWithReExecute("/Home/Status", "?code={0}");
//Hata sayfasýný kullanabilmek için bunu ekliyoruz ve bir hata olursa istediðimiz sayfaya yönlendiriyoruz. Yazmýþ olduðumuz ?code={0} ile hatanýn statuscode'nu yakalýyoruz. Hata yakalama middleware'i diðer middleware'lerin üstünde tanýmlanmalýdýr. Olmayan sayfalara vb. gidilmek istendiðinde çalýþýr.

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
