using MarqueeLabelSample.ViewModel;
using Syncfusion.XForms.Buttons;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace MarqueeLabelSample.Behaviors
{
    [Preserve(AllMembers = true)]
    public class MarqueeBehavior : Behavior<StackLayout>
    {
        #region Properties

        private StackLayout stack { get; set; }
        private bool isStartTimer;

        public double PageWidth
        {
            get { return (double)GetValue(PageWidthProperty); }
            set { SetValue(PageWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PageWidth.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty PageWidthProperty =
            BindableProperty.Create("PageWidth", typeof(double), typeof(MarqueeBehavior));

        #endregion

        #region Methods

        protected override void OnAttachedTo(StackLayout stackLayout)
        {
            base.OnAttachedTo(stackLayout);
            this.stack = stackLayout;
            isStartTimer = true;
            stackLayout.BindingContextChanged += StackLayout_BindingContextChanged;
        }

        /// <summary>
        /// This event is invoked when stacklayout binding context is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StackLayout_BindingContextChanged(object sender, EventArgs e)
        {
            StackLayout stackLayout = sender as StackLayout;
            if (stackLayout.BindingContext != null && stackLayout.BindingContext is MainPageViewModel mainPageViewModel && mainPageViewModel != null)
            {
                if (mainPageViewModel.Controls != null && mainPageViewModel.Controls.Count > 0)
                {
                    foreach (var control in mainPageViewModel.Controls)
                    {
                        stackLayout.Children.Add(GetNewButton((control.Description), int.Parse(control.PriorityId), control.PreviewImage));
                    }

                    StartAnimation();
                }
            }
        }

        /// <summary>
        /// This method is used for staring the marquee scrolling animation.
        /// </summary>
        private void StartAnimation()
        {
            Device.StartTimer(TimeSpan.FromMilliseconds(50), () =>
            {
                stack.TranslationX -= 5f;

                if (Math.Abs(stack.TranslationX) > stack.Width)
                {
                    stack.TranslationX = PageWidth;
                }
                return isStartTimer;
            });
        }

        /// <summary>
        /// This method is used for getting the marquee label content.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="PriorityId"></param>
        /// <returns></returns>
        private SfButton GetNewButton(string content, int priorityId, string imageName)
        {
            var button = new SfButton()
            {
                FontSize = 16,
                Text = content,
                HeightRequest = 45,
                HasShadow = false,
                Margin = new Thickness(0, 0, 8, 0),
                Padding = new Thickness(12, 0, 18, 0),
                ImageSource = imageName,
                ShowIcon = true,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                TextColor = (Color)Application.Current.Resources["ContentTextColor"],
                BackgroundColor = GetPriorityColor(priorityId),
                VerticalOptions = LayoutOptions.Center,

            };

            button.Clicked += (sender, args) =>
            {
                //Perform marquee selected item.
            };

            return button;
        }

        /// <summary>
        /// This method is used to return the color based on priority level.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private Color GetPriorityColor(int id)
        {
            if (id == 1)
                return (Color)Application.Current.Resources["HighPriorityBackgroundColor"];
            else if (id == 2)
                return (Color)Application.Current.Resources["NormalPriorityBackgroundColor"];
            else
                return (Color)Application.Current.Resources["LowPriorityBackgroundColor"];
        }

        protected override void OnDetachingFrom(StackLayout stackLayout)
        {
            stackLayout.BindingContextChanged -= StackLayout_BindingContextChanged;
            isStartTimer = false;
            base.OnDetachingFrom(stackLayout);
        }

        #endregion
    }
}
