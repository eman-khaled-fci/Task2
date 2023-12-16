using Microsoft.Extensions.FileProviders;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {

        services.AddControllers();


        services.Configure<IISServerOptions>(options =>
        {
            options.AllowSynchronousIO = true;
        });


    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {


        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });


    }
}
