using BlankApp2.Models;
using Prism.Navigation;
using Reactive.Bindings;

namespace BlankApp2.ViewModels
{
    public class SelectionPageViewModel : ViewModelBase
    {
        public SelectionPageViewModel(INavigationService navigationService, CoreModel coreModel) : base(navigationService)
        {
            Counters = coreModel.Counters.ToReadOnlyReactiveCollection();

            // 選ばれたものをCoreModelのCurrentCounterにセットして、DetailPageに遷移する
            SelectCommand = new ReactiveCommand<CounterModel>()
                .WithSubscribe(async counter =>
                {
                    coreModel.CurrentCounter = counter;
                    await navigationService.NavigateAsync("DetailPage");
                });
        }

        public ReadOnlyReactiveCollection<CounterModel> Counters { get; }
        public ReactiveCommand<CounterModel> SelectCommand { get; }
    }
}
