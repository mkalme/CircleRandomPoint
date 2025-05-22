using System;
using System.Collections.Generic;

namespace CircleRandomPoint {
    class Circle {
        public int Radius { get; set; }
        public List<Point> RandomPoints { get; set; }

        public Circle(int radius) {
            Radius = radius;
            RandomPoints = new List<Point>();
        }
    }

    struct Point {
        public float HorizontalRatio { get; set; }
        public float VerticalRatio { get; set; }

        public Point(float horizontalRatio, float verticalRatio) {
            HorizontalRatio = horizontalRatio;
            VerticalRatio = verticalRatio;
        }
    }
}
