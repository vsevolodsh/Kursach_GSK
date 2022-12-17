using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSC_Kursach
{
    internal class Str2 : Primitive
    {
        
        public Str2(Graphics g, Pen DrawPen, List<PointF> VertexList) : base(g, DrawPen, VertexList)
        {
            this.g = g;
            this.DrawPen = DrawPen;
            this.VertexList = VertexList;
        }
        public void setPoints(Point startPoint)
        {
            VertexList.Add(new Point(startPoint.X - 100, startPoint.Y - 20));
            VertexList.Add(new Point(startPoint.X - 100, startPoint.Y - 60));
            VertexList.Add(new Point(startPoint.X - 160, startPoint.Y));
            VertexList.Add(new Point(startPoint.X - 100, startPoint.Y + 60));
            VertexList.Add(new Point(startPoint.X - 100, startPoint.Y + 20));
            VertexList.Add(new Point(startPoint.X + 100, startPoint.Y + 20));
            VertexList.Add(new Point(startPoint.X + 100, startPoint.Y + 60));
            VertexList.Add(new Point(startPoint.X + 160, startPoint.Y));
            VertexList.Add(new Point(startPoint.X + 100, startPoint.Y - 60));
            VertexList.Add(new Point(startPoint.X + 100, startPoint.Y - 20));

        }
    }

}