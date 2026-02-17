namespace MauiApp1.ViewModels
{
    public partial class MainViewModel(ISemanticScreenReader screenReader) : BaseViewModel("MauiApp1")
    {
        private int _count;
        private RelayCommand? incrementCommand;

        public IRelayCommand IncrementCommand => incrementCommand ??= new RelayCommand(new Action(Increment));

        [ObservableProperty]
        public partial string CountText { get; private set; } = "Current count: 0";

        //[RelayCommand] - Won't work as the generated Command won't be visible to .NET MAUI Source Gen
        private void Increment()
        {
            _count++;
            CountText = $"Current count: {_count}";
            screenReader.Announce(CountText);
        }
    }
}
