using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Para.Data.Context;
using Para.Data.UnitOfWork;

namespace Para.Api;

public class Startup
{
    public IConfiguration Configuration;
    
    public Startup(IConfiguration configuration)
    {
        this.Configuration = configuration;
    }
    
    
    [Obsolete("Obsolete")]
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews()
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());
        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Para.Api", Version = "v1" });
        });
        var connectionStringPostgres = Configuration.GetConnectionString("PostgresSqlConnection");
        services.AddDbContext<ParaPostgreDbContext>(options => options.UseNpgsql(connectionStringPostgres));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Para.Api v1"));
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