using System;
using Microsoft.Extensions.DependencyInjection;

namespace P07.InfernoInfinity
{
    class StartUp
    {
        static void Main()
        {
            IServiceProvider serviceProvider = ConfigureSerevice();
            ICommandInterpreter commandInterpreter = new CommandInterpreter(serviceProvider);
            IRunnable engine = new Engine(commandInterpreter);
            engine.Run();
        }

        private static IServiceProvider ConfigureSerevice()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<IRepository, WeaponRepository>();
            services.AddTransient<IWeaponFactory, WeaponFactory>();
            services.AddTransient<IGemFactory, GemFactory>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
