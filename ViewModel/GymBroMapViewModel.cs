using CommunityToolkit.Mvvm.Input;
using GymBro.Commands;
using System.Windows.Input;
namespace GymBro.ViewModel
{
    public partial class GymBroMapViewModel : BaseViewModel
    {
        public GymBroMapViewModel(/*IGeolocation geolocation*/)
        {
            Title = "Nearest Gyms";
            /*
            ButtonMap = new MapCommand();
            this.geolocation = geolocation;
            */
        }
        /*
        public ICommand ButtonMap { get; }
        IGeolocation geolocation;
        [RelayCommand]
        async Task GetLocationAsync()
        {
            try
            {
                var location = await geolocation.GetLocationAsync();
                if (location is null)
                {
                    location = await geolocation.GetLocationAsync(
                        new GeolocationRequest
                        {
                            DesiredAccuracy = GeolocationAccuracy.Medium,
                            Timeout = TimeSpan.FromSeconds(30),
                        });
                }

                if (location == null)
                    return;
                await Shell.Current.DisplayAlert("GPS:",
                $"{location.Latitude} in {location.Longitude}", "OK");
            }
            catch (Exception e)
            {

            }
            finally
            {

            }
        }
        */
        [RelayCommand]
        async Task OpenMapAsync()
        {
            try
            {
                Uri uri = new Uri("https://www.google.com/maps/search/gym");
                await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                // An unexpected error occured. No browser may be installed on the device.
            }
        }
    }
}
