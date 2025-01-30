using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageIDE
{
    internal interface Shapes
    {
        void set(params int[] list);
        void draw(Graphics g, bool fill, Color color);
    }
}
