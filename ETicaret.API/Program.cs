
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
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace ETicaret.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddSwaggerDocument();//Swager için eklendi
            builder.Services.AddAutoMapper(typeof(MapProfile));

            builder.Services.AddScoped<IYetkilerService, YetkilerService>();
            builder.Services.AddScoped<IErisimAlanlariService, ErisimAlanlariService>();
            builder.Services.AddScoped<IKullanicilarService, KullanicilarService>();
            builder.Services.AddScoped<IService<ErisimAlanlari>, ErisimAlanlariService>();
            builder.Services.AddScoped<IService<Yetkiler>, YetkilerService>();
            builder.Services.AddScoped<IUrunlerRepository, UrunlerRepository>();
            builder.Services.AddScoped<IUrunlerService, UrunlerService>();
            builder.Services.AddScoped<IKullanicilarRepository, KullanicilarRepository>();

            //
            builder.Services.AddScoped<IFotograflarRepository, FotograflarRepository>();
            builder.Services.AddScoped<IFotograflarService, FotograflarService>();
            builder.Services.AddScoped<IService<Fotograflar>, FotograflarService>();

            //

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

            //**********************
            app.UseOpenApi();//Swager da API çalıştırmak için eklendi
            app.UseSwaggerUi();//Swageri run eder
            //**********************
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
