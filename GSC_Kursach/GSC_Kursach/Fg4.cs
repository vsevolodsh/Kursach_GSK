using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSC_Kursach
{
    internal class Fg4 : Primitive
    {
        public Fg4(Graphics g, Pen DrawPen, List<PointF> VertexList) : base(g, DrawPen, VertexList)
        {
            this.g = g;
            this.DrawPen = DrawPen;
            this.VertexList = VertexList;
        }
        public void setPoints(Point startPoint)
        {
            VertexList.Add(startPoint);
            VertexList.Add(new Point(startPoint.X + 50, startPoint.Y - 100));
            VertexList.Add(new Point(startPoint.X + 150, startPoint.Y - 100));
            VertexList.Add(new Point(startPoint.X + 100, startPoint.Y + 50));
            VertexList.Add(new Point(startPoint.X - 100, startPoint.Y + 50));
            VertexList.Add(new Point(startPoint.X - 150, startPoint.Y - 100));
            VertexList.Add(new Point(startPoint.X - 50, startPoint.Y - 100));
        }
    }

}
