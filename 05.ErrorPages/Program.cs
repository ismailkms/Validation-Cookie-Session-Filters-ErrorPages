var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseExceptionHandler("/Home/Error");
//Program�n i�erisinde olu�an hatalar� yakalamam�z� sa�lar. Program bir hata atarsa o zaman �al���r.
app.UseStatusCodePagesWithReExecute("/Home/Status", "?code={0}");
//Hata sayfas�n� kullanabilmek i�in bunu ekliyoruz ve bir hata olursa istedi�imiz sayfaya y�nlendiriyoruz. Yazm�� oldu�umuz ?code={0} ile hatan�n statuscode'nu yakal�yoruz. Hata yakalama middleware'i di�er middleware'lerin �st�nde tan�mlanmal�d�r. Olmayan sayfalara vb. gidilmek istendi�inde �al���r.

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
