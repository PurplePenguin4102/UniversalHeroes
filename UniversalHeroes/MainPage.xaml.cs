using System;
using System.Numerics;
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
using Windows.UI.WebUI;
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
            Window.Current.CoreWindow.PointerPressed += MouseClick;
            Window.Current.CoreWindow.PointerMoved += MouseMoved;
            Window.Current.CoreWindow.ResizeCompleted += WindowResized;
        }

        private void WindowResized(CoreWindow sender, object args)
        {
            SetGameField();
        }

        private void MouseMoved(CoreWindow sender, PointerEventArgs args)
        {
            var point = new Point(Math.Round(args.CurrentPoint.Position.X), Math.Round(args.CurrentPoint.Position.Y));
            var offset = MySplitView.IsPaneOpen ? 200 : 50;
            MouseLocation.Text = $"{point.X},{point.Y} :: {point.X - offset},{point.Y}";
        }

        private void MouseClick(CoreWindow sender, PointerEventArgs args)
        {
            var point = args.CurrentPoint.Position;
            var offset = MySplitView.IsPaneOpen ? 200: 50;
            ViewModel.GameModel.ClickEvents.Enqueue(new Point(point.X - offset, point.Y));
        }

        private void UserKeyUp(CoreWindow sender, KeyEventArgs args)
        {
            ViewModel.GameModel.KeyState.Remove(args.VirtualKey);
        }

        private void UserKeyDown(CoreWindow sender, KeyEventArgs args)
        {
            ViewModel.GameModel.KeyState.Add(args.VirtualKey);
        }

        private void ExpandoButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
            SetGameField();
        }

        private void SetGameField()
        {
            var offset = MySplitView.IsPaneOpen ? 200 : 50;
            ViewModel.GameModel.Gamefield = new Rect(0, 0, Window.Current.CoreWindow.Bounds.Width - offset, Window.Current.CoreWindow.Bounds.Width - offset);
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void ViewField_CreateResources(CanvasControl sender, CanvasCreateResourcesEventArgs args)
        {
            ViewModel.GameModel.GameInit();
            SetGameField();
            foreach (var actor in ViewModel.GameModel.Actors)
            {
                actor.RenderGeometry(sender);       
            }
            
            ViewModel.StartGame();
        }

        private async void ViewField_OnDraw(CanvasControl sender, CanvasDrawEventArgs args)
        {
            using (var sesh = args.DrawingSession)
            {
                foreach (var actor in ViewModel.GameModel.Actors)
                {
                    sesh.FillGeometry(actor.Geometry, new Vector2(0f, 0f), actor.Brush);
                }
            }

            await Task.Delay(1);
            ViewField.Invalidate();
        }
    }
}
