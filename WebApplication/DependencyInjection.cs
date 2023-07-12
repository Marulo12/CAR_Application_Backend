namespace WebApp
{
    public static class DependencyInjection
    {
        public static void AddServiceWebApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                     builder => builder.SetIsOriginAllowed(_ => true)
                     .AllowAnyMethod()
                     .AllowAnyHeader().AllowCredentials());
            });
        }
    }
}
