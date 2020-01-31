using BlankApp2.Models;
using Prism;
using Prism.Ioc;
using BlankApp2.ViewModels;
using BlankApp2.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BlankApp2
{
    public partial class App
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // 「なんか全体的なデータを保持したりするモデル」はシングルトンで裏に居座ってもらう
            containerRegistry.RegisterSingleton<CoreModel>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<SinglePage, SinglePageViewModel>();
            containerRegistry.RegisterForNavigation<ListPage, ListPageViewModel>();
        }
    }
}
