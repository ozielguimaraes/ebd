using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ebd.Mobile.Views.Components
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuCardView : Frame
    {
        public MenuCardView()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
            propertyName: nameof(Title),
            returnType: typeof(string),
            declaringType: typeof(MenuCardView),
            defaultValue: null);

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly BindableProperty IconSourceProperty = BindableProperty.Create(
            propertyName: nameof(IconSource),
            returnType: typeof(ImageSource),
            declaringType: typeof(MenuCardView),
            defaultValue: null);

        public ImageSource IconSource
        {
            get => (ImageSource)GetValue(IconSourceProperty);
            set => SetValue(IconSourceProperty, value);
        }
    }
}