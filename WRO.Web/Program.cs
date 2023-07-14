using WRO.Web;

// INFO: Admin panelin öz səhifəsi sadəcə Azərbaycan dilində ola bilər amma bu o qədər də faydalı olacaq kimi görünmür.

// DONE: Qeydiyyatdan keçmiş istifadəçilərin list olunduğu səhifədə illərə görə filtrlama aparıla bilsin.
//       Buna əsasən exceldə illərə görə yükləmə dəyişilsin.

// DONE: Bizimlə əlaqə bölməsi admin panelə əlavə olunmalıdı. Buradan məlumatlar dəyişilə bilməlidi.

// DONE: Admin panelə galeriya bölməsi əlavə olunmalıdı. Admin dinamik olaraq şəkilləri əlavə edə bilməlidi.

// DONE: Komandalar admin paneldə həm sezona, həm kateqoriyaya, həm də qalib olmalarına görə sıralana bilir.
// TODO: UI üçün də eynisilə qaliblər əlavə olunub həm sezona həm də kateqoriyaya əsasən sıralana bilməlidi

// DONE: Şəkillərin ölçüsü üçün limit olsun

// DONE: Əsas səhifəyə elanlar düşməlidi

// DONE: Əsas səhifəyə qaleriyadan şəkillər düşməlidi

// DONE: Clear migrations

// DONE: Qalereyada təkcə il üzrə filter olacağ

// TODO: Add README to final product. Explain controversial and complex parts of program.

/* TODO: 4 kateqoriya görsənirdi əsas səhifədə onların hər hansına basanda seçilmiş kateqoriyaya görə filter olsun
 * NOTE: burada yönləndirələcək səhifə səhv eləmirəmsə olimpiyadalar səhifəsi olmalıdı. 
 * yönləndirmə zamanı querystring-ə category dəyərini guid tipində versək heç bir problem qalmıyacaq
 * front bitdikdən sonra həll olacaq
 */

var builder = WebApplication.CreateBuilder(args);

// Custom service extensions

builder.Services.AddMvcServices();

builder.Services.AddLocalizationServices();

builder.Services.AddHelperServices();


builder.Services.AddDataServices(builder.Configuration);

builder.Services.AddSecurityServices();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var app = builder.Build();

app.ConfigureDatabase(builder.Configuration);


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/Error/{0}");


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseRequestLocalization();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
