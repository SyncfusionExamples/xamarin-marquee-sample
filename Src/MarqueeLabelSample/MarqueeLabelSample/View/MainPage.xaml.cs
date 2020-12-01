using MarqueeLabelSample.ViewModel;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace MarqueeLabelSample
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    [Preserve(AllMembers = true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }
    }
}
