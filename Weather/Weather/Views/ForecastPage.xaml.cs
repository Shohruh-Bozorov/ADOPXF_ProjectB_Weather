using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Weather.Models;
using Weather.Services;

namespace Weather.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class ForecastPage : ContentPage
    {
        OpenWeatherService service;
        GroupedForecast groupedforecast;

        public ForecastPage()
        {
            InitializeComponent();
            
            service = new OpenWeatherService();
            groupedforecast = new GroupedForecast();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //Code here will run right before the screen appears
            //You want to set the Title or set the City
            myLabel.Text = Title;
            
            //This is making the first load of data
            MainThread.BeginInvokeOnMainThread(async () => {await LoadForecast();});

        }

        private async Task LoadForecast()
        {
            
            Forecast forecast  = await service.GetForecastAsync(Title); //Heare you load the forecast  
            myList.ItemsSource = forecast.Items.GroupBy(o => o.DateTime.Date);

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await LoadForecast();
        }

    }
}