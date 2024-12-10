using System.Reflection;

namespace RentACar.WebUI
{
    public static class ServicesRegistration
    {
        public static void AddUIService(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);
        }
    }
}
