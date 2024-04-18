using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Windows.Input;
using BabyYoda.Models;

namespace BabyYoda
{
    public partial class MainPage : ContentPage
    {
        private string _funfact;

        public string FunFact
        {
            get { return _funfact; }
            set
            {
                _funfact = value;

                _funfact = value;
                OnParentChanged();
            }
        }

        public ICommandMapper NewfactCommand { get; set; }
        private HttpClient _client;

        public MainPage()
        {
            InitializeComponent();

            NewfactCommand = new Command(Getfunfact);

            BindingContext = this;

            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
        }
        public async void Getfunfact(object parameters)
        {
            string response = await _client.GetStringAsync(new Uri("https://babyyoda.openai.azure.com/"));

            Yodafact responsefact = JsonConvert.DeserializeObject<Yodafact>(response);

            if (responsefact != null)
            {
                funfact = responsefact.fact;
            }


        }

    }
}
