﻿using System;
using Microsoft.Extensions.DependencyInjection;
using Forum.App.Contracts;
using Forum.App.Menus;

namespace Forum.App
{
	internal class MenuController : IMainController
	{
		private IServiceProvider serviceProvider;

		private IForumViewEngine forumViewer;
		private ISession session;
		private ICommandFactory commandFactory;

		public MenuController(IServiceProvider serviceProvider, IForumViewEngine viewEngine, ISession session, ICommandFactory commandFactory)
		{
			this.serviceProvider = serviceProvider;
			this.forumViewer = viewEngine;
			this.session = session;
			this.commandFactory = commandFactory;

			this.InitializeSession();
		}

		private string Username { get; set; }

		private IMenu CurrentMenu => this.session.CurrentMenu;

		private void InitializeSession()
		{
			this.session.PushView(new MainMenu(this.session,
				this.serviceProvider.GetService<ILabelFactory>(),
				this.serviceProvider.GetService<ICommandFactory>()));

			this.RenderCurrentView();
		}

		private void RenderCurrentView()
		{
			this.forumViewer.RenderMenu(this.CurrentMenu);
		}

		public void MarkOption()
		{
			this.forumViewer.Mark(this.CurrentMenu.CurrentOption);
		}

		public void UnmarkOption()
		{
			this.forumViewer.Mark(this.CurrentMenu.CurrentOption, false);
		}

		public void NextOption()
		{
			this.CurrentMenu.NextOption();
		}

		public void PreviousOption()
		{
			this.CurrentMenu.PreviousOption();
		}

		public void Back()
		{
			this.session.Back();
			RenderCurrentView();
		}

		public void Execute()
		{
			this.session.PushView(this.CurrentMenu.ExecuteCommand());
			this.RenderCurrentView();
		}
	}
}