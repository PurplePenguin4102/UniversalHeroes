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



using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Windows.UI.Core;


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
                case VirtualKey.Right: ViewModel.YellowGuy.Command = GuyCommands.StopX; break;
                case VirtualKey.Left: ViewModel.YellowGuy.Command = GuyCommands.StopX; break;
                case VirtualKey.Up: ViewModel.YellowGuy.Command = GuyCommands.StopY; break;
                case VirtualKey.Down: ViewModel.YellowGuy.Command = GuyCommands.StopY; break;
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

        private void yellowGuy_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ViewModel.YellowGuy.Selected = true;
        }

        private void Page_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (e.OriginalSource is Canvas)
                ViewModel.YellowGuy.Selected = false;
        }
    }
}
