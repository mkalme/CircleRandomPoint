using System;
using System.Drawing;

namespace CircleRandomPoint {
    class Render {
        private Circle Circle { get; set; }

        private Bitmap Bitmap { get; set; }
        private Graphics Graphics { get; set; }

        public Render(Circle circle) {
            Circle = circle;
        }

        public Bitmap RenderCircle() {
            Bitmap = new Bitmap(Circle.Radius * 2 + 2, Circle.Radius * 2 + 2);
            Graphics = Graphics.FromImage(Bitmap);

            DrawBitmap();

            return Bitmap;
        }

        private void DrawBitmap() {
            Graphics.Clear(Color.FromArgb(35, 35, 35));

            Graphics.DrawEllipse(new Pen(Color.White, 1), 0, 0, Circle.Radius * 2 + 1, Circle.Radius * 2 + 1);

            DrawPoints();
        }
        private void DrawPoints() {
            int radius = Circle.Radius;

            for (int i = 0; i < Circle.RandomPoints.Count; i++) {
                Point point = Circle.RandomPoints[i];

                float s = radius - Math.Abs(radius - radius * point.HorizontalRatio * 2);
                float segitta = (float)Math.Sqrt(2 * radius * s - s * s);

                int x = (int)(radius * point.HorizontalRatio * 2) + 1;
                int y = radius * 2 - (int)(radius - segitta + (segitta * 2 * point.VerticalRatio));

                Graphics.FillRectangle(new SolidBrush(Color.White), x, y, 1, 1);
            }
        }
    }
}
