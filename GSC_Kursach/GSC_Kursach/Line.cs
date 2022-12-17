using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSC_Kursach
{
    internal class Line: Primitive
    {
        public Line(Graphics g, Pen DrawPen, List<PointF> VertexList) : base(g, DrawPen, VertexList)
        {
            this.g = g;
            this.DrawPen = DrawPen;
            this.VertexList = VertexList;
        }

        public void drawLine(Pen pen)
        {
            g.DrawLine(pen, VertexList[0], VertexList[1]);
        }
        
    }
}
