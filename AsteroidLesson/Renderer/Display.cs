using AsteroidLesson.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AsteroidLesson.Renderer
{
    public class Display : FrameworkElement
    {
        Size area;
        IGameModel model;

        public void SetupSizes(Size area)
        {
            this.area = area;
            this.InvalidateVisual();
        }

        public void SetupModel(IGameModel model)
        {
            this.model = model;
            this.model.Changed += (sender, eventargs) => this.InvalidateVisual();
        }

        public Brush SpaceBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "space.png"), UriKind.RelativeOrAbsolute)));
            }
        }

        public Brush ShipBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "falcon_rotated.png"), UriKind.RelativeOrAbsolute)));
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            //

            if (area.Width > 0 && area.Height > 0 && model != null)
            {
                drawingContext.DrawRectangle(SpaceBrush, null, new Rect(0, 0, area.Width, area.Height));

                drawingContext.PushTransform(new RotateTransform(model.Ship.Angle, model.Ship.Position.X + 25, model.Ship.Position.Y + 25));
                drawingContext.DrawRectangle(ShipBrush, null, new Rect(model.Ship.Position.X,model.Ship.Position.Y, 50, 50));
                drawingContext.Pop();

                foreach (var item in model.Lasers)
                {
                    drawingContext.DrawEllipse(Brushes.Red, null, item.Center, 5, 5);
                }
            }
        }
    }
}
