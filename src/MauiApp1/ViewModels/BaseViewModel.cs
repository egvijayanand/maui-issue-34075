namespace MauiApp1.ViewModels
{
    public partial class BaseViewModel(string title = "") : ObservableObject
    {
        [ObservableProperty]
        public partial string Title { get; set; } = title;
    }
}
