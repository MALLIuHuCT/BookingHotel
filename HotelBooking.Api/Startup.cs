using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using HotelBooking.Application;
using HotelBooking.DataAccess.MSSQL;
using HotelBooking.DataAccess.MSSQL.Repositories;
using HotelBooking.Domain.IRepositories;
using HotelBooking.Domain.IServices;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Api
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
            services.AddAutoMapper(typeof(DataAccessMappingProfile));

            services.AddTransient<IHotelRepository, HotelRepository>();
            services.AddTransient<IHotelService, HotelService>();
            
            services.AddTransient<IHotelImageRepository, HotelImageRepository>();
            services.AddTransient<IHotelImageService, HotelImageService>();

            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<IRoomService, RoomService>();

            services.AddTransient<IBookingRepository, BookingRepository>();
            services.AddTransient<IBookingService, BookingService>();

            services.AddTransient<IChequeRepository, ChequeRepository>();
            services.AddTransient<IChequeService, ChequeService>();

            services.AddDbContext<BookingHotelsContext>(x =>
                x.UseSqlServer(Configuration.GetConnectionString("ConnectionDbContext")));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HotelBooking.Api", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                c.IncludeXmlComments("HotelBooking.Api.xml");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "HotelBooking.Api v1");
                });

                
                app.UseReDoc(c =>
                {
                    c.SpecUrl("/swagger/v1/swagger.json");
                    c.EnableUntrustedSpec();
                    c.ScrollYOffset(10);
                    c.HideHostname();
                    c.HideDownloadButton();
                    c.ExpandResponses("200,201");
                    c.RequiredPropsFirst();
                    c.NoAutoAuth();
                    c.PathInMiddlePanel();
                    c.HideLoading();
                    c.NativeScrollbars();
                    c.DisableSearch();
                    c.OnlyRequiredInSamples();
                    c.SortPropsAlphabetically();
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
