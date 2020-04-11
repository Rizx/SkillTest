using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using SkillTest.Core;
using Microsoft.OpenApi.Models;
using Swashbuckle;
using System.Reflection;
using System.IO;

namespace SkillTest.API
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
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" }));

            var connection = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<SkillTestContext>(opt =>
                opt.UseOracle(connection)
            );

            services.AddScoped<Messages>();
            services.AddScoped<ISkillTestContext, SkillTestContext>();
            services.AddScoped<IQueryHandler<LokasiListQuery, List<LokasiDto>>, LokasiQueryHandler>();
            services.AddScoped<IQueryHandler<DataListQuery, List<DataDto>>, DataQueryHandler>();
            services.AddScoped<IQueryHandler<DataSingleByIdQuery, Data>, DataQueryHandler>();
            services.AddScoped<IQueryHandler<GroupByLokasiQuery, List<GroupByLokasiDto>>, GroupByLokasiQueryHandler>();

            services.AddScoped<ICommandHandler<DataCreateCommand>,DataCommandHandler>();
            services.AddScoped<ICommandHandler<DataUpdateCommand>,DataCommandHandler>();
            services.AddScoped<ICommandHandler<DataUpdateJudulCommand>,DataCommandHandler>();
            services.AddScoped<ICommandHandler<DataDeleteCommand>,DataCommandHandler>();
            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
