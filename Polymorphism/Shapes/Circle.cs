using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;


        public double Radius
        {
            get => this.radius;
            private set
            {
                if (value <= 0)
                    throw new Exception("Invalid radius");
                radius = value;
            }
        }
        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override string Draw()
        {
            StringBuilder builder = new StringBuilder();

            double rIn = this.radius - 0.4;
            double rOut = this.radius + 0.4;
            for (double y = this.radius; y >= -this.radius; --y)
            {
                for (double x = -this.Radius; x < rOut; x += 0.5)
                {
                    double value = x * x + y * y;

                    if (value >= rIn * rIn && value <= rOut * rOut)
                        builder.Append("*");
                    else builder.Append(" ");
                }
                builder.AppendLine();
            }

            return builder.ToString();
        }
    }
}
