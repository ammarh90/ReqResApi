using ReqResApi.API.Controllers;
using ReqResApi.API.Interfaces;
using ReqResApi.BusinessLayer;

namespace ReqResApi.IoC
{
    public class DependancyContainer
    {
        public static void RegisterClients(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddTransient<UserController>();

            services.AddHttpClient("ReqRes", c =>
            {
                //c.BaseAddress = new Uri(Configuration["ReqResUri"].ToString());
                c.BaseAddress = new Uri("https://reqres.in");
                c.DefaultRequestHeaders.Add("Accept", "application/json");
                //c.DefaultRequestHeaders.Add("Authorization", Configuration["Authorization"].ToString());

            });
        }
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
