using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Mvc.Presentation;
using Sitecore.Data.Fields;
using MvcNewsApp.Data.Entities.Interfaces;
using MvcNewsApp.Data.Entities.Controls;
using MvcNewsApp.Data.ModelMapper;


namespace MvcNewsApp.Data.Entities.Controls
{
	[ModelMapper("0ee22e81-0a86-48bd-ae53-19f221506353")]
	public partial class SidebarItem : BaseEntity, IRenderingModel	
	{

        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);

			Text = rendering.Item["Text"];
			Title = rendering.Item["Title"];
		}

		// Fields for SidebarItem
		public string Text { get; set; }
		public string Title { get; set; }
	}
}


namespace MvcNewsApp.Data.Entities.Interfaces
{
	public partial interface IMetadata : IBaseEntity	
	{

		// Fields for IMetadata
		string Description { get; set; }
		string Keywords { get; set; }
	}
}


namespace MvcNewsApp.Data.Entities.Controls
{
	[ModelMapper("47e7156c-1c6d-4143-8c08-93471351914b")]
	public partial class FooterLink : BaseEntity, IRenderingModel	
	{

        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);

			Link = rendering.Item.Fields["Link"];
		}

		// Fields for FooterLink
		public LinkField Link { get; set; }
	}
}


namespace MvcNewsApp.Data.Entities
{
	[ModelMapper("4b48820f-b6b2-4c03-a47a-fed7ccf52f28")]
	public partial class Home : Page, IRenderingModel	
	{

        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);

		}

		// Fields for Home
	}
}


namespace MvcNewsApp.Data.Entities.Controls
{
	[ModelMapper("53a0a37f-4b42-4686-9ffc-25d1e073f971")]
	public partial class PageFooter : BaseEntity, IRenderingModel	
	{

        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);

			FooterMessage = rendering.Item["FooterMessage"];
		}

		// Fields for PageFooter
		public string FooterMessage { get; set; }
	}
}


namespace MvcNewsApp.Data.Entities.Interfaces
{
	public partial interface INavigable : IBaseEntity	
	{

		// Fields for INavigable
		string NavigationTitle { get; set; }
	}
}


namespace MvcNewsApp.Data.Entities
{
	[ModelMapper("67bc8148-23bc-4c57-b4dc-098e6cb8ad51")]
	public partial class Page : BaseEntity, IMetadata, INavigable, IRenderingModel	
	{

        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);

			Body = rendering.Item["Body"];
			Title = rendering.Item["Title"];
			Description = rendering.Item["Description"];
			Keywords = rendering.Item["Keywords"];
			NavigationTitle = rendering.Item["NavigationTitle"];
		}

		// Fields for Page
		public string Body { get; set; }
		public string Title { get; set; }

		// Fields for IMetadata
		public string Description { get; set; }
		public string Keywords { get; set; }

		// Fields for INavigable
		public string NavigationTitle { get; set; }
	}
}


namespace MvcNewsApp.Data.Entities
{
	[ModelMapper("780d1f2c-5dbc-487b-bc9e-31b1b3d57ccf")]
	public partial class Article : Page, IRenderingModel	
	{
		private MultilistField _RelatedArticles;

        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);

			ArticleDate = rendering.Item.Fields["ArticleDate"];
			HeaderImage = rendering.Item.Fields["HeaderImage"];
			_RelatedArticles = rendering.Item.Fields["RelatedArticles"];
			Summary = rendering.Item["Summary"];
			SummaryImage = rendering.Item.Fields["SummaryImage"];
		}

		// Fields for Article
		public DateField ArticleDate { get; set; }
		public ImageField HeaderImage { get; set; }
		public IEnumerable<Article> RelatedArticles 
		{
			get
			{
				return ModelFactory.Models<Article>(_RelatedArticles.GetItems());
			}
		}
		public string Summary { get; set; }
		public ImageField SummaryImage { get; set; }
	}
}


namespace MvcNewsApp.Data.Entities
{
	[ModelMapper("e5798f79-8c77-4ffb-86ca-0ecd61b8f521")]
	public partial class News : Page, IRenderingModel	
	{
		private MultilistField _Sidebar;

        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);

			_Sidebar = rendering.Item.Fields["Sidebar"];
		}

		// Fields for News
		public IEnumerable<SidebarItem> Sidebar 
		{
			get
			{
				return ModelFactory.Models<SidebarItem>(_Sidebar.GetItems());
			}
		}
	}
}
