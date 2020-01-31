using System.Linq;
using BlankApp2.Models;
using Prism.Navigation;
using Reactive.Bindings;

namespace BlankApp2.ViewModels
{
    public class ListPageViewModel : ViewModelBase
    {
        public ListPageViewModel(INavigationService navigationService, CoreModel coreModel) : base(navigationService)
        {
            // 子が入ってるCollectionView用
            // CollectionViewのリスト。CounterModelのリストを元にして、新しくCounterViewModelのリストを作ってる
            CounterViewModels = coreModel.Counters.ToReadOnlyReactiveCollection(x => new CounterViewModel(x));

            // ここから下、親ページ用の機能
            // Picker用のリスト
            Counters = coreModel.Counters.ToReadOnlyReactiveCollection();
            // Pickerで選択中のカウンタ。初期値で先頭のやつを入れてある。
            SelectedCounter = new ReactiveProperty<CounterModel>(Counters.First());
            // 選んだやつのUpを実行
            UpCommand = new ReactiveCommand();
            UpCommand.Subscribe(() => SelectedCounter.Value.Up());
            // 選んだやつのDownを実行
            DownCommand = new ReactiveCommand();
            DownCommand.Subscribe(() => SelectedCounter.Value.Down());
        }

        public ReadOnlyReactiveCollection<CounterViewModel> CounterViewModels { get; }
        public ReadOnlyReactiveCollection<CounterModel> Counters { get; }
        public ReactiveProperty<CounterModel> SelectedCounter { get; }
        public ReactiveCommand UpCommand { get; }
        public ReactiveCommand DownCommand { get; }
    }
}
