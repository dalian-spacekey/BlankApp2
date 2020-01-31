using System.Linq;
using BlankApp2.Models;
using Prism.Navigation;
using Reactive.Bindings;

namespace BlankApp2.ViewModels
{
    public class SinglePageViewModel : ViewModelBase
    {
        public SinglePageViewModel(INavigationService navigationService, CoreModel coreModel) : base(navigationService)
        {
            // 画面に出るカウンター用のViewModelを作る(とりあえず最初のやつ)
            CounterViewModel = new ReactiveProperty<CounterViewModel>(new CounterViewModel(coreModel.Counters.First()));
        }

        public ReactiveProperty<CounterViewModel> CounterViewModel { get; }
    }
}
