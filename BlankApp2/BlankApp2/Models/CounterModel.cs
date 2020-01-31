using Prism.Mvvm;

namespace BlankApp2.Models
{
    /// <summary>
    /// 「カウンター」のデータや処理が設定されているモデル
    /// </summary>
    public class CounterModel : BindableBase
    {
        public void Up() => Count++;
        public void Down() => Count--;

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        private string name;

        public int Count
        {
            get => count;
            set => SetProperty(ref count, value);
        }

        private int count;
    }
}
