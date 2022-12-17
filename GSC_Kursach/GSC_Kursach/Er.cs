using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSC_Kursach
{
    internal class Er : Primitive
    {
        public Er(Graphics g, Pen DrawPen, List<PointF> VertexList) : base(g, DrawPen, VertexList)
        {
            this.g = g;
            this.DrawPen = DrawPen;
            this.VertexList = VertexList;
        }

        public void DrawCubeSpline(Pen pen)
        {
            PointF[] L = new PointF[4]; // Матрица вещественных коэффициентов
            PointF Pv1 = VertexList[0];
            PointF Pv2 = VertexList[0];
            const double dt = 0.04;
            double t = 0;
            double xt, yt;
            PointF Ppred = VertexList[0], Pt = VertexList[0];
            // Касательные векторы
            Pv1.X = 4 * (VertexList[1].X - VertexList[0].X);
            Pv1.Y = 4 * (VertexList[1].Y - VertexList[0].Y);
            Pv2.X = 4 * (VertexList[3].X - VertexList[2].X);
            Pv2.Y = 4 * (VertexList[3].Y - VertexList[2].Y);
            // Коэффициенты полинома
            L[0].X = 2 * VertexList[0].X - 2 * VertexList[2].X + Pv1.X + Pv2.X; // Ax
            L[0].Y = 2 * VertexList[0].Y - 2 * VertexList[2].Y + Pv1.Y + Pv2.Y; // Ay
            L[1].X = -3 * VertexList[0].X + 3 * VertexList[2].X - 2 * Pv1.X - Pv2.X; // Bx
            L[1].Y = -3 * VertexList[0].Y + 3 * VertexList[2].Y - 2 * Pv1.Y - Pv2.Y; // By
            L[2].X = Pv1.X; // Cx
            L[2].Y = Pv1.Y; // Cy
            L[3].X = VertexList[0].X; // Dx
            L[3].Y = VertexList[0].Y; // Dy
            while (t < 1 + dt / 2)
            {
                xt = ((L[0].X * t + L[1].X) * t + L[2].X) * t + L[3].X;
                yt = ((L[0].Y * t + L[1].Y) * t + L[2].Y) * t + L[3].Y;
                Pt.X = (int)Math.Round(xt);
                Pt.Y = (int)Math.Round(yt);
                g.DrawLine(pen, Ppred, Pt);
                Ppred = Pt;
                t = t + dt;
            }
        }
    }
}
