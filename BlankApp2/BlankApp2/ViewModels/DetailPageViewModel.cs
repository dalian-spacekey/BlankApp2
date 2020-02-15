using System.Reactive.Linq;
using BlankApp2.Models;
using Prism.Navigation;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace BlankApp2.ViewModels
{
    public class DetailPageViewModel : ViewModelBase
    {
        public DetailPageViewModel(INavigationService navigationService, CoreModel coreModel) : base(navigationService)
        {
            // DetailPageは、coreModelのCurrentCounterに追従するだけ
            CounterViewModel = coreModel
                .ObserveProperty(x => x.CurrentCounter)
                .Select(x => new CounterViewModel(x))
                .ToReactiveProperty();
        }

        public ReactiveProperty<CounterViewModel> CounterViewModel { get; }
    }
}
