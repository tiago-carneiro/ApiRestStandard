using ApiRestStandard;
using Newtonsoft.Json;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace AppTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var client = new ApiRest("http://www.mocky.io");
                var loginResponse = await client.GetAsync<ResponseData>("/v2/5c9575723600006300941f57");
            }
            catch (ApiException apiEx)
            {

            }
            catch (Exception ex)
            {

            }
        }
    }

    [Preserve(AllMembers = true)]/*Sdk and User Assemblies*/
    public class ResponseData
    {
        [JsonProperty("key")]
        public string Key { get; set; }
    }
}
