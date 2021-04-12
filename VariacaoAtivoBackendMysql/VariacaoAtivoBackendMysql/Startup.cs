using VariacaoAtivoBackendMysql.Database;
using VariacaoAtivoBackendMysql.Repositorios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using VariacaoAtivoBackendMysql.Servicos;
using VariacaoAtivoBackendMysql.Interfaces;

namespace VariacaoAtivoBackendMysql
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string conexaoMysql = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContextPool<AplicacaoDbContexto>(options => options.UseMySql(conexaoMysql, ServerVersion.AutoDetect(conexaoMysql)));

            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddControllers();

            services.AddScoped<AplicacaoDbContexto, AplicacaoDbContexto>();
            services.AddTransient(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
            services.AddTransient<IAcaoServico, AcaoServico>();
            services.AddTransient<IAcaoRepositorio, AcaoRepositorio>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VariacaoAtivoBackendMysql", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VariacaoAtivoBackendMysql v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
                        
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
