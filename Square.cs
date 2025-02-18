﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageIDE
{
    public class Square:Shape
    {
        private int size;

        public Square() : base()
        {

        }
        public Square(Color colour, int x, int y, int size) : base(colour, x, y)
        {
            this.size = size;
        }
        public override void set(params int[] list)
        {
            //list[0] is x, list[1] is y, list[2] is width, list[3] is height
            base.set(list[0], list[1]);
            this.size = list[2];
            

        }
        //no draw method here because it is provided by the parent class Rectangle
        public override void draw(Graphics g, bool fill, Color color)
        {
            if (fill)
            {
                SolidBrush brush = new SolidBrush(color);
                g.FillRectangle(brush, x, y, size, size);
            }
            else
            {
                Pen pen = new Pen(color, 2);
                g.DrawRectangle(pen, x, y, size, size);
            }
        }

    }
}
