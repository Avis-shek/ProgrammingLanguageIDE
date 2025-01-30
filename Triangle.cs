using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageIDE
{
    public class Triangle:Shape
    {
        int side1, side2, side3;
        public Triangle() : base()
        {

        }

        public Triangle(Color colour, int x, int y, int s1, int s2, int s3) : base(colour, x, y)
        {
            this.side1 = s1;
            this.side2 = s2;
            this.side3 = s3;

        }

        public override void set(params int[] list)
        {
            //list[0] is x, list[1] is y, list[2] is width, list[3] is height
            base.set(list[0], list[1]);
            this.side1 = list[2];
            this.side2 = list[3];
            this.side3 = list[4];

        }
        public override void draw(Graphics g, bool fill, Color color)
        {

            PointF firstPoint = new PointF(side1, side2);
            PointF secPoint = new PointF(side2, side3);

            //finding average point
            double avgY = (Math.Pow(side1, 2) + Math.Pow(side3, 2) - Math.Pow(side2, 2)) / (side1 * 2);
            double avgX = Math.Sqrt(Math.Pow(side3, 2) - Math.Pow(avgY, 2));

            PointF thirdPoint = new PointF((float)avgX, (float)avgY);


            if (fill)
            {
                SolidBrush brush = new SolidBrush(color);
                PointF[] allPoints = new PointF[] { firstPoint, secPoint, thirdPoint };
                g.FillPolygon(brush, allPoints);
            }
            else
            {
                Pen pen = new Pen(color, 2);
                //PointF[] allPoints = new PointF[] { firstPoint, secPoint, thirdPoint };
                //g.DrawPolygon(pen,allPoints);
                g.DrawLine(pen, firstPoint, secPoint);
                g.DrawLine(pen, secPoint, thirdPoint);
                g.DrawLine(pen, thirdPoint, firstPoint);
            }

        }

      

    }
}
