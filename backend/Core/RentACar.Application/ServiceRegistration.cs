using Microsoft.Extensions.DependencyInjection;
using RentACar.Application.Features.CQRS.Handlers.AboutHandlers;
using RentACar.Application.Features.CQRS.Handlers.BannerHandlers;
using RentACar.Application.Features.CQRS.Handlers.BrandHandlers;
using RentACar.Application.Features.CQRS.Handlers.CarHandlers;
using RentACar.Application.Features.CQRS.Handlers.CategoryHandlers;
using RentACar.Application.Features.CQRS.Handlers.ContactHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationService(this IServiceCollection services)
        {
            //services.AddMediatR(Assembly.GetExecutingAssembly()); --->sürümden dolayı hata veriyor mediatR 12 de

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly));



            services.AddScoped<GetAboutQueryHandler>();
            services.AddScoped<GetAboutByIdQueryHandler>();
            services.AddScoped<CreateAboutCommandHandler>();
            services.AddScoped<UpdateAboutCommandHandler>();
            services.AddScoped<RemoveAboutCommandHandler>();

            services.AddScoped<GetBannerQueryHandler>();
            services.AddScoped<GetBannerByIdQueryHandler>();
            services.AddScoped<CreateBannerCommandHandler>();
            services.AddScoped<UpdateBannerCommandHandler>();
            services.AddScoped<RemoveBannerCommandHandler>();

            services.AddScoped<GetBrandQueryHandler>();
            services.AddScoped<GetBrandByIdQueryHandler>();
            services.AddScoped<CreateBrandCommandHandler>();
            services.AddScoped<UpdateBrandCommandHandler>();
            services.AddScoped<RemoveBrandCommandHandler>();

            services.AddScoped<GetCarQueryHandler>();
            services.AddScoped<GetCarByIdQueryHandler>();
            services.AddScoped<CreateCarCommandHandler>();
            services.AddScoped<UpdateCarCommandHandler>();
            services.AddScoped<RemoveCarCommandHandler>();
            services.AddScoped<GetCarWithBrandQueryHandler>();
            services.AddScoped<GetLast5CarsWithBrandQueryHandler>();

           

            services.AddScoped<GetCategoryQueryHandler>();
            services.AddScoped<GetCategoryByIdQueryHandler>();
            services.AddScoped<CreateCategoryCommandHandler>();
            services.AddScoped<UpdateCategoryCommandHandler>();
            services.AddScoped<RemoveCategoryCommandHandler>();

            services.AddScoped<GetContactQueryHandler>();
            services.AddScoped<GetContactByIdQueryHandler>();
            services.AddScoped<CreateContactCommandHandler>();
            services.AddScoped<UpdateContactCommandHandler>();
            services.AddScoped<RemoveContactCommandHandler>();
        }
    }
}
