using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace GymBro.ViewModel
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;

        [ObservableProperty]
        string title;

        public bool IsNotBusy => !IsBusy;
        public ObservableCollection<String> Gym { get; } = new();
    }
}
