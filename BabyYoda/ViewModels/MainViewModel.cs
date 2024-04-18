using CommunityToolkit.Mvvm.Input;
using MauiAppShellMvvm.Services;

namespace MauiAppShellMvvm.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        private IExampleCounterStore _exampleCounterStore;
		private int _counter;

        private string _counterDescription;

        public string CounterDescription
        {
            get { return _counterDescription; }
            set
            {
                _counterDescription = value;

                OnPropertyChanged();
            }
        }


        [RelayCommand]
        public void CounterIncrement(object param)
        {
            _counter++;

            _exampleCounterStore.UpdateCounter(_counter);

            UpdateCounterDescription();

            SemanticScreenReader.Announce(CounterDescription);
        }

        private void UpdateCounterDescription()
        {
            if (_counter == 1)
                CounterDescription = $"Clicked {_counter} time";
            else
                CounterDescription = $"Clicked {_counter} times";
        }

        public MainViewModel(IExampleCounterStore counterstore)
		{
            _exampleCounterStore = counterstore;

            CounterDescription = "Click Me";

            _counter = _exampleCounterStore.GetLatestCounter();

            if (_counter != 0 )
            UpdateCounterDescription();
        }
    }
}
