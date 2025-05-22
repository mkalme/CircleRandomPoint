using System;
using System.Drawing;

namespace CircleRandomPoint {
    class CirclePoints {
        public Circle Circle { get; set; }
        private Render Render { get; set; }

        public CirclePoints(int radius) {
            Circle = new Circle(radius);
            Render = new Render(Circle);
        }

        public Bitmap RenderCircle() {
            return Render.RenderCircle();
        }
    }
}
