using MauiAppShellMvvm.ViewModels;

namespace MauiAppShellMvvm
{
    public partial class MainView : ContentPage
    {
        public MainView(MainViewModel vm)
        {
            InitializeComponent();

            BindingContext = vm;
        }

        
    }

}
