using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.System;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml.Shapes;
using Microsoft.Graphics.Canvas.UI;
using Microsoft.Graphics.Canvas.UI.Xaml;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UniversalHeroes
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public GameViewModel ViewModel { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            this.ViewModel = new GameViewModel();
            Window.Current.CoreWindow.KeyDown += UserKeyDown;
            Window.Current.CoreWindow.KeyUp += UserKeyUp;
        }

        private void UserKeyUp(CoreWindow sender, KeyEventArgs args)
        {
        }

        private void UserKeyDown(CoreWindow sender, KeyEventArgs args)
        {

        }

        private void ExpandoButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void ThisPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void ViewField_CreateResources(CanvasControl sender, CanvasCreateResourcesEventArgs args)
        {
            //throw new NotImplementedException();
        }

        private void ViewField_OnDraw(CanvasControl sender, CanvasDrawEventArgs args)
        {
            //throw new NotImplementedException();
            args.DrawingSession.DrawEllipse(155, 115, 80, 30, Colors.Black, 3);
            args.DrawingSession.DrawText("Hello, world!", 100, 100, Colors.Yellow);
        }
    }
}
