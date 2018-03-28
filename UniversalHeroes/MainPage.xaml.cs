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
using Windows.UI.Core;
using Windows.UI.Xaml.Shapes;


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
            switch (args.VirtualKey)
            {
                case VirtualKey.Right: ViewModel.YellowGuy.Command = GuyCommands.StopRight; break;
                case VirtualKey.Left: ViewModel.YellowGuy.Command = GuyCommands.StopLeft; break;
                case VirtualKey.Up: ViewModel.YellowGuy.Command = GuyCommands.StopUp; break;
                case VirtualKey.Down: ViewModel.YellowGuy.Command = GuyCommands.StopDown; break;
            }
        }

        private void UserKeyDown(CoreWindow sender, KeyEventArgs args)
        {
            switch (args.VirtualKey)
            {
                case VirtualKey.Right: ViewModel.YellowGuy.Command = GuyCommands.GoRight; break;
                case VirtualKey.Left: ViewModel.YellowGuy.Command = GuyCommands.GoLeft; break;
                case VirtualKey.Up: ViewModel.YellowGuy.Command = GuyCommands.GoUp; break;
                case VirtualKey.Down: ViewModel.YellowGuy.Command = GuyCommands.GoDown; break;
            }
        }

        private void ExpandoButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void rectangle_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            var rect = sender as Rectangle;
            var selectedGuy = ViewModel.Actors.First(a => a.Name == rect.Name);
            var blime = selectedGuy as SelectableGuy; 
            blime.Selected = true;
        }

        private void Page_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (e.OriginalSource is Canvas)
                ViewModel.YellowGuy.Selected = false;
        }

        private void ThisPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ViewModel.GroundGuy.Width = ThisPage.ActualWidth;
            ViewModel.GroundGuy.Height = ThisPage.ActualHeight;
        }
    }
}
