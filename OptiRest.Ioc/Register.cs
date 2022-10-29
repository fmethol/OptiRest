using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OptiRest.Data.Context;
using OptiRest.Service.Interfaces;
using OptiRest.Service.Services;

namespace OptiRest.Ioc
{
    public static class Register
    {
        public static void RegisterServices(IServiceCollection services, string connectionString)
        {
            // Add the Database Context here
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            // Add Services
            services.AddTransient<ITakedRangeService, TakedRangeService>();
            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<IItemCategoryService, ItemCategoryService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<IStateService, StateService>();
            services.AddTransient<ITenantService, TenantService>();
            services.AddTransient<IBusinessConfigService, BusinessConfigService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAreaService, AreaService>();
            services.AddTransient<ITableService, TableService>();
            services.AddTransient<ITableShapeService, TableShapeService>();
            services.AddTransient<ITableStateService, TableStateService>();
            services.AddTransient<ITableServiceService, TableServiceService>();
            services.AddTransient<IServiceStateService, ServiceStateService>();
            services.AddTransient<IDinerUserService, DinerUserService>();
            services.AddTransient<ITableService2ItemService, TableService2ItemService>();
            services.AddTransient<IKitchenService, KitchenService>();
            services.AddTransient<IOrderService, OrderService>();

        }
    }
}