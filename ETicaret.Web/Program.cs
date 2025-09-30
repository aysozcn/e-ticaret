
using ETicaret.Core.ETicaretDatabase;
using ETicaret.Core.IRepositories;
using ETicaret.Core.IService;
using ETicaret.Core.IUnitOfWork;
using ETicaret.Repository;
using ETicaret.Repository.Repositories;
using ETicaret.Repository.UntiOfWork;
using ETicaret.Service.Mapping;
using ETicaret.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Reflection;

namespace ETicaret.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region SessionCagirma
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);//oturum süresi belirtilmiştir
                options.Cookie.HttpOnly = true;//güvenlik ayarı yapılmıştır
                options.Cookie.IsEssential = true;//güvenlik ayarı yapılmıştır
            });
			#endregion

			//builder.Services.AddControllersWithViews().AddSessionStateTempDataProvider();
			//builder.Services.AddHttpContextAccessor();
			//builder.Services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();
			// Add services to the container.
			builder.Services.AddControllersWithViews();

            #region E Ticaret Service'leri
            
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IAdreslerService, AdreslerService>();
            builder.Services.AddScoped<IAdreslerRepository, AdreslerRepository>();
            builder.Services.AddScoped<IKategoriRepository, KategoriRepository>();
            builder.Services.AddScoped<IKategoriService, KategorilerService>();
            builder.Services.AddScoped<IKullanicilarService, KullanicilarService>();
            builder.Services.AddScoped<IilRepository, ILRepository>();
            builder.Services.AddScoped<IilService, IlService>();
            //builder.Services.AddScoped<ISepetlerService, SepetlerService>();
            builder.Services.AddScoped<IUrunlerRepository, UrunlerRepository>();
            builder.Services.AddScoped<IKullanicilarRepository, KullanicilarRepository>();
            builder.Services.AddScoped<IPersonellerRepository, PersonellerRepository>();
           // builder.Services.AddScoped<IMenulerRepository, MenulerRepository>();
            builder.Services.AddScoped<IMusterilerService, MusterilerService>();
            builder.Services.AddScoped<IMusterilerRepository, MusterilerRepository>();
           // builder.Services.AddScoped<IMenulerService, MenulerService>();
            builder.Services.AddScoped<IErisimAlanlariService, ErisimAlanlariService>();
            builder.Services.AddScoped<IUrunlerService, UrunlerService>();
            builder.Services.AddScoped<IKullanicilarService, KullanicilarService>();
            builder.Services.AddScoped<IPersonellerService, PersonellerService>();
            builder.Services.AddScoped<IPersonellerService, PersonellerService>();
            builder.Services.AddScoped<IPersonellerRepository, PersonellerRepository>();
            builder.Services.AddScoped<IYetkilerService, YetkilerService>();
            builder.Services.AddAutoMapper(typeof(MapProfile));
            builder.Services.AddScoped<IYorumlarRepository, YorumlarRepository>();
            builder.Services.AddScoped<IYorumlarService, YorumlarService>();
            builder.Services.AddScoped<IKullanicilarRepository, KullanicilarRepository>();
            builder.Services.AddScoped<IKullanicilarService, KullanicilarService>();
            builder.Services.AddScoped<IYetkiErisimService, YetkiErisimService>();

            builder.Services.AddScoped<IFotograflarRepository, FotograflarRepository>();
            builder.Services.AddScoped<IFotograflarService, FotograflarService>();

            //Urunler,Kategoriler, Yorumlar, Fotograflar,...
            //builder.Services.AddScoped<ISepetlerRepository, SepetlerRepository>();
			builder.Services.AddSession();
            
            
			//Urunler,Kategoriler, Yorumlar, Fotograflar,...

			// Urunler, Kategoriler
			#endregion

			#region DB işlemleri

			builder.Services.AddDbContext<AppDbContext>(x =>
            {
                x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
                {
                    //option.MigrationsAssembly("ETicaret.Repository");//Hangi katmanda DB tanımlı ise o katman yazılır. Bunu yerine Assembly Reflection yapısı ile AppDbContext'in olduğu katmanı bulup ismini çekebiliriz
                    option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
                });
            });
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

			app.UseSession();

			app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //Admin Panel için Route yönlendirmesi
                endpoints.MapAreaControllerRoute(
                 name: "AdminDefaultRoute",
                 areaName: "AdminPanel",
                 pattern: "AdminPanel/{controller=AdminAnasayfa}/{action=AdminAnasayfaIndex}/{id?}"
                 //http://localhost:5012/admin => şeklinde roue verildiğinde Controller ve action da yazılanlar çıkacaktır
                 );

                app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });


            app.Run();
        }
    }
}
