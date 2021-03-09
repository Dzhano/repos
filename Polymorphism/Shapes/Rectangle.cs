using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public double Height
        {
            get => this.height;
            private set
            {
                if (value <= 0)
                    throw new Exception("Invalid height");
                height = value;
            }
        }
        public double Width
        {
            get => this.width;
            private set
            {
                if (value <= 0)
                    throw new Exception("Invalid width");
                width = value;
            }
        }

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public override double CalculateArea()
        {
            return Height * Width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (Height + Width);
        }
        public override string Draw()
        {
            StringBuilder builder = new StringBuilder();

            /* for (double i = 0; i < Height; i++)
            {
                for (double y = 0; y < Width; y++) 
                    builder.Append("*");
                builder.AppendLine();
            } */
            for (double y = 0; y < Width; y++)
                builder.Append("*");
            builder.AppendLine();
            for (double i = 1; i < Height - 1; i++)
            {
                builder.Append("*");
                for (double y = 1; y < Width - 1; y++)
                    builder.Append(" ");
                builder.Append("*");
                builder.AppendLine();
            }
            for (double y = 0; y < Width; y++)
                builder.Append("*");
            builder.AppendLine();

            return builder.ToString();
        }
    }
}
