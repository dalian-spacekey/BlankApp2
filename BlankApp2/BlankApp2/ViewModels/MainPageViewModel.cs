using Prism.Navigation;
using Reactive.Bindings;

namespace BlankApp2.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            MoveSinglePageCommand = new ReactiveCommand();
            MoveSinglePageCommand.Subscribe(async () => await navigationService.NavigateAsync("SinglePage"));

            MoveListPageCommand = new ReactiveCommand();
            MoveListPageCommand.Subscribe(async () => await navigationService.NavigateAsync("ListPage"));

            SelectionPageCommand = new ReactiveCommand();
            SelectionPageCommand.Subscribe(async () => await navigationService.NavigateAsync("SelectionPage"));

        }

        public ReactiveCommand MoveSinglePageCommand { get; }
        public ReactiveCommand MoveListPageCommand { get; }
        public ReactiveCommand SelectionPageCommand { get; }

    }
}
