using BlankApp2.Models;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace BlankApp2.ViewModels
{
    /// <summary>
    /// カウンター機能部分のViewModel
    /// これはPrismに世話してもらわず、ページの方で自分で管理してビューに割り当てる
    /// </summary>
    public class CounterViewModel
    {
        public CounterViewModel(CounterModel counterModel)
        {
            // もらったCounterModelに対する処理をやるようにしておく
            CounterName = counterModel.ObserveProperty(x => x.Name).ToReactiveProperty();
            Count = counterModel.ObserveProperty(x => x.Count).ToReactiveProperty();

            UpCommand = new ReactiveCommand();
            UpCommand.Subscribe(counterModel.Up);

            DownCommand = new ReactiveCommand();
            DownCommand.Subscribe(counterModel.Down);
        }

        public ReactiveProperty<string> CounterName { get; }
        public ReactiveProperty<int> Count { get; }

        public ReactiveCommand UpCommand { get; }
        public ReactiveCommand DownCommand { get; }
    }
}
