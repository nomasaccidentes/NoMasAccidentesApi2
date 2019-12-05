using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NoMasAccidentesApi.Repositories;

namespace NoMasAccidentesApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddTransient<IRolRepository, RolRepository>();
            services.AddTransient<IPagosRepository, PagosRepository>();
            services.AddTransient<ISolicitudAsesoria, SolicitudAsesoriaRepository>();
            services.AddTransient<ISolicitudCapacitacionRepository, SolicitudCapacitacionRepository>();
            services.AddTransient<IDetalleCapacitacionRepository, DetalleCapacitacionRepository>();
            services.AddTransient<IAsesoriaRepository, AsesoriaRepository>();
            services.AddTransient<IAsesoriaDetalleRepository, AsesoriaDetalleRepository>();
            services.AddTransient<IReporteAccidenteDetalleRepository, ReporteAccidenteDetalleRepository>();
            services.AddTransient<IRegistroAccidenteRepository, RegistroAccidenteRepository>();
            services.AddTransient<INoMasAccidentesRepository, NoMasAccidentesRepository>();
            services.AddTransient<ICapacitacionRepository, CapacitacionRepository>();
            services.AddTransient<IContratoRepository, ContratoRepository>();
            services.AddTransient<IServicioRepository, ServicioRepository>();
            services.AddTransient<IActividadRepository, ActividadRepository>();
            services.AddTransient<IProfesionalRepository, ProfesionalRepository>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IRubroRepository, RubroRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddSingleton<IConfiguration>(Configuration);
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors("MyPolicy");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseMvc();
        }
    }
}
