using MarqueeLabelSample.Model;
using System.Collections.ObjectModel;

namespace MarqueeLabelSample.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {
        #region Privates

        private ObservableCollection<Control> controls;

        #endregion

        #region Constructor

        public MainPageViewModel()
        {
            GetControls();
        }

        #endregion

        #region Properties

        public ObservableCollection<Control> Controls
        {
            get { return controls; }
            set { controls = value; OnPropertyChanged(); }
        }

        #endregion

        #region Methods

        public void GetControls()
        {
            Controls = new ObservableCollection<Control>();
            Controls.Add(new Control { Name = "Chat",  Description = "Chat - Provides a modern conversational UI to facilitate conversation between two or more users.", PreviewImage = "https://help.syncfusion.com/xamarin/chat/sfchat_images/xamarin-forms-chat-timebreak-mode.png", PriorityId = "1" });
            Controls.Add(new Control { Name = "Button", Description = "Button - Customize a button as an outline, flat, circle, or icon button.", PreviewImage = "https://help.syncfusion.com/xamarin/button/images/overview.png", PriorityId = "3" });
            Controls.Add(new Control { Name = "TabbedView", Description = "TabbedView - It provides nested tab support with different header placement support.", PreviewImage = "https://help.syncfusion.com/xamarin/tabbed-view/images/getting-started/xamarin_forms_tabview.png", PriorityId = "2" });
            Controls.Add(new Control { Name = "ListView", Description = "ListView - Easily arrange items in a vertical or horizontal manner.", PreviewImage = "https://help.syncfusion.com/xamarin/listview/sflistview_images/overview.png", PriorityId = "1" });
            Controls.Add(new Control { Name = "Rotator", Description = "Rotator - Thumbnails display mode helps users preview all items.", PreviewImage = "https://help.syncfusion.com/xamarin-ios/sfrotator/images/rotator.png", PriorityId = "3" });
        }

        #endregion

    }
}
