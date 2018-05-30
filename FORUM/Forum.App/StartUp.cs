using System;
using Microsoft.Extensions.DependencyInjection;
using Forum.Data;
using Forum.App.Contracts;
using Forum.App.Models;
using Forum.App.Factories;
using Forum.App.Services;

namespace Forum.App
{
	public class StartUp
	{
		public static void Main()
		{
			IServiceProvider serviceProvider = ConfigureServices();
			IMainController menu = serviceProvider.GetService<IMainController>();

			Engine engine = new Engine(menu);
			engine.Run();
		}

		private static IServiceProvider ConfigureServices()
		{
			IServiceCollection services = new ServiceCollection();

			services.AddTransient<ICommandFactory, CommandFactory>();
			services.AddTransient<ILabelFactory, LabelFactory>();
			services.AddTransient<IMenuFactory, MenuFactory>();
			services.AddTransient<ITextAreaFactory, TextAreaFactory>();

			services.AddSingleton<ForumData>();
			services.AddTransient<IPostService, PostService>();
			services.AddTransient<IUserService, UserService>();

			services.AddSingleton<ISession, Session>();
			services.AddSingleton<IForumViewEngine, ForumViewEngine>();
			services.AddSingleton<IMainController, MenuController>();

			services.AddTransient<IForumReader, ForumConsoleReader>();

			IServiceProvider serviceProvider = services.BuildServiceProvider();
			return serviceProvider;
		}
	}
}
