using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Mvvm;

namespace BlankApp2.Models
{
    /// <summary>
    /// なんか全体的なデータを保持したりするモデルがあるとする
    /// </summary>
    public class CoreModel : BindableBase
    {
        public CoreModel()
        {
            Counters = new ObservableCollection<CounterModel>(
                new List<CounterModel>
                {
                    new CounterModel { Name = "Counter-1" },
                    new CounterModel { Name = "Counter-2" },
                    new CounterModel { Name = "Counter-3" }
                });
        }

        public ObservableCollection<CounterModel> Counters { get; }

        /// <summary>
        /// 現在の対象カウンター
        /// </summary>
        public CounterModel CurrentCounter
        {
            get => currentCounter;
            set => SetProperty(ref currentCounter, value);
        }
        private CounterModel currentCounter;
    }
}
