using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ebd.Mobile.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class BottomSheetControl : ContentView
    {
        public BottomSheetControl()
        {
            InitializeComponent();
            this.SizeChanged += (s, e) =>
            {
                var heightRequest = this.Height * HeightPercentage;

                switch (Device.Idiom)
                {
                    case TargetIdiom.Phone:
                        if (DeviceDisplay.MainDisplayInfo.Width < 720)
                        {
                            heightRequest *= 70;
                            heightRequest *= 1.7;
                        }
                        break;
                    case TargetIdiom.Tablet:
                        heightRequest *= 0.8;
                        break;
                }

                SheetContainer.HeightRequest = heightRequest;
            };

            this.InputTransparent = true;
        }

        private void CloseButtonClicked(object sender, EventArgs e)
        {
            Hide();
        }

        private void OnOverlayTapped(object sender, EventArgs e)
        {
            Hide();
        }

        public void ShowOrHide()
        {
            if (SheetContainer.IsVisible)
                Hide();
            else
                Show();
        }

        public void Show()
        {
            Overlay.IsVisible = true;
            SheetContainer.IsVisible = true;
            this.InputTransparent = false;
            var overlayFade = new Animation(v => Overlay.Opacity = v, 0, 0.5);
            var bottomSheetTranslate = new Animation(v => SheetContainer.TranslationY = v, SheetContainer.HeightRequest, 0);

            var animation = new Animation
            {
                { 0, 1, overlayFade },
                { 0, 1, bottomSheetTranslate }
            };

            animation.Commit(this, "ShowBottomSheet", length: 500);
        }

        public void Hide()
        {
            var overlayFade = new Animation(v => Overlay.Opacity = v, 0.5, 0);
            var bottomSheetTranslate = new Animation(v => SheetContainer.TranslationY = v, 0, SheetContainer.HeightRequest);
            var animation = new Animation
            {
                { 0, 1, overlayFade },
                { 0, 1, bottomSheetTranslate }
            };

            animation.Commit(this, "HideBottomSheet", length: 500, finished: (v, c) =>
            {
                Overlay.IsVisible = false;
                SheetContainer.IsVisible = false;
                this.InputTransparent = true;
            });
        }

        public static readonly BindableProperty SheetContentProperty = BindableProperty.Create(nameof(SheetContent), typeof(View), typeof(BottomSheetControl), propertyChanged: OnSheetContentChanged);
        public View SheetContent
        {
            get => (View)GetValue(SheetContentProperty);
            set => SetValue(SheetContentProperty, value);
        }

        private static void OnSheetContentChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is BottomSheetControl control && newValue is View view)
            {
                control.SheetContentView.Content = view;
            }
        }

        public static readonly BindableProperty HeightPercentageProperty = BindableProperty.Create(nameof(HeightPercentage), typeof(double), typeof(BottomSheetControl), 50d, propertyChanged: OnSheetHeightPercentageChanged);

        public double HeightPercentage
        {
            get { return (double)GetValue(HeightPercentageProperty); }
            set { SetValue(HeightPercentageProperty, value); }
        }

        private static void OnSheetHeightPercentageChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (BottomSheetControl)bindable;
            if (control != null && newValue is double newHeightPercentage)
            {
                control.SheetContainer.HeightRequest = control.Height * (newHeightPercentage / 100);
            }
        }
    }
}
