using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSC_Kursach
{
    internal class Tmo : Primitive
    {
        public List<PointF> VertexList1 = new List<PointF>();
        public List<PointF> VertexList2 = new List<PointF>();



        public Tmo(Graphics g, Pen DrawPen, List<PointF> VertexList1, List<PointF> VertexList2) : base(g, DrawPen)
        {
            this.g = g;
            this.DrawPen = DrawPen;
            this.VertexList1 = VertexList1;
            this.VertexList2 = VertexList2;
        }

        void crossPointTMO(List<int> Xl, List<int> Xr, int Y, List<PointF> VertexList, int maxIndex)
        {
            int k;
            bool CW;
            if (Opred(maxIndex, VertexList) < 0) CW = true; else CW = false;
            for (int i = 0; i < VertexList.Count; i++)
            {
                if (i < (VertexList.Count - 1))
                {
                    k = i + 1;
                }
                else
                {
                    k = 0;
                }
                //нахождение точек пересечения
                if ((VertexList[i].Y < Y) & (VertexList[k].Y >= Y) ||
                (VertexList[i].Y >= Y) & (VertexList[k].Y < Y))
                {
                    int x = (int)((VertexList[i].X * VertexList[k].Y -
                    VertexList[k].X * VertexList[i].Y - Y * (VertexList[i].X - VertexList[k].X)) /
                    (VertexList[k].Y - VertexList[i].Y));
                    if (!CW)
                    {
                        if ((VertexList[k].Y - VertexList[i].Y) < 0)
                        {
                            Xl.Add(x);
                        }
                        else if ((VertexList[k].Y - VertexList[i].Y) > 0)
                        {
                            Xr.Add(x);
                        }
                    }
                    else
                    {
                        if ((VertexList[k].Y - VertexList[i].Y) < 0)
                        {
                            Xr.Add(x);
                        }
                        else if ((VertexList[k].Y - VertexList[i].Y) > 0)
                        {
                            Xl.Add(x);
                        }
                    }
                }
            }
            Xr.Sort();
            Xl.Sort();
        }

        public void makeTMO(int[] SetQ)
        {
            float Ymax, Ymin, Y;
            int maxIndex;
            YminMax(out Ymin, out Ymax, out maxIndex);
            for (Y = Ymin; Y <= Ymax; Y++)
            {
                List<int> Xal = new List<int>();
                List<int> Xar = new List<int>();
                List<int> Xbl = new List<int>();
                List<int> Xbr = new List<int>();
                crossPointTMO(Xal, Xar, (int)Y, VertexList1, maxIndex);
                crossPointTMO(Xbl, Xbr, (int)Y, VertexList2, maxIndex);
                if (Xal.Count == 0 && Xbl.Count == 0)
                    continue;
                int[][] M = new int[Xal.Count * 2 + Xbl.Count * 2][];
                int n = Xal.Count;
                for (int i = 0; i < n; i++)
                {
                    M[i] = new int[2] { Xal[i], 2 };
                }
                int nM = n; n = Xar.Count;
                for (int i = 0; i < n; i++)
                {
                    M[nM + i] = new int[2] { Xar[i], -2 };
                }
                nM = nM + n; n = Xbl.Count;
                for (int i = 0; i < n; i++)
                {
                    M[nM + i] = new int[2] { Xbl[i], 1 };
                }
                nM = nM + n; n = Xbr.Count;
                for (int i = 0; i < n; i++)
                {
                    M[nM + i] = new int[2] { Xbr[i], -1 };
                }
                nM = nM + n;

                //общее число элементов в массиве M
                //сортировка массива М()
                for (int i = 0; i < M.Length; i++)
                {
                    for (int j = 0; j < M.Length - 1; j++)
                    {
                        if (M[j][0] > M[j + 1][0])
                        {
                            int[] tempArr1 = new int[2];
                            Array.Copy(M[j], tempArr1, 2);
                            int[] tempArr2 = new int[2];
                            Array.Copy(M[j + 1], tempArr2, 2);
                            M[j] = tempArr2;
                            M[j + 1] = tempArr1;
                        }
                    }
                }

                int k = 0, m = 0;
                int Q = 0, x = 0, Xemin = 0, Qnew = 0;
                List<int> Xrl = new List<int>();
                List<int> Xrr = new List<int>();


                if (M[0][0] >= Xemin && M[0][1] < 0)
                {
                    Xrl.Add(0);
                    Q = -M[0][1];
                    k = 2;
                }
                for (int i = 0; i < nM; i++)
                {
                    x = M[i][0];
                    Qnew = Q + M[i][1];
                    if (!Array.Exists(SetQ, element => element == Q) &&
                        Array.Exists(SetQ, element => element == Qnew))
                    {
                        Xrl.Add(x);
                        k += 1;
                    }
                    if (Array.Exists(SetQ, element => element == Q) &&
                        !Array.Exists(SetQ, element => element == Qnew))
                    {
                        Xrr.Add(x);
                        m += 1;
                    }
                    Q = Qnew;
                }

                for (int i = 0; i < Xrr.Count; i++)
                {
                    g.DrawLine(DrawPen, new Point(Xrr[i], (int)Y), new Point(Xrl[i], (int)Y));
                }
            }
        }

        public PointF findCenterTmo()
        {
            PointF center = new PointF();
            float Xcenter1 = 0, Ycenter1 = 0, Xcenter2 = 0, Ycenter2 = 0;
            for (int i = 0; i < VertexList1.Count; i++)
            {
                Xcenter1 += VertexList1[i].X;
                Ycenter1 += VertexList1[i].Y;
            }
            for (int i = 0; i < VertexList2.Count; i++)
            {
                Xcenter2 += VertexList2[i].X;
                Ycenter2 += VertexList2[i].Y;
            }
            center.X = (Xcenter1 / VertexList1.Count + Xcenter2 / VertexList2.Count) / 2;
            center.Y = (Ycenter1 / VertexList1.Count + Ycenter2 / VertexList2.Count) / 2;
            return center;
        }


        private int Opred(int j, List<PointF> FigNum)
        {
            int jl = j - 1;
            if (jl < 0) jl = FigNum.Count - 1;
            int jp = j + 1;
            if (jp >= FigNum.Count) jp = 0;
            PointF p1 = FigNum[jl];
            PointF p2 = FigNum[j];
            PointF p3 = FigNum[jp];
            int op = (int)(p1.X * p2.Y + p2.X * p3.Y + p3.X * p1.Y -
                (p3.X * p2.Y + p2.X * p1.Y + p1.X * p3.Y));
            op = op / 2;
            if (op == 0) op = Opred(jp, FigNum);
            return op;
        }
        void YminMax(out float Ymin, out float Ymax, out int maxIndex)
        {
            maxIndex = 0;
            List<PointF> fig1 = VertexList1;
            List<PointF> fig2 = VertexList2;
            Ymin = fig1[0].Y;
            Ymax = fig1[0].Y;
            float min2 = fig2[0].Y;
            float max2 = fig2[0].Y;

            for (int i = 1; i < fig1.Count; i++)
            {
                if (fig1[i].Y > Ymax)
                {
                    Ymax = fig1[i].Y;
                    maxIndex = i;
                }
                if (fig1[i].Y < Ymin)
                {
                    Ymin = fig1[i].Y;
                }
            }

            for (int i = 1; i < fig2.Count; i++)
            {
                if (fig2[i].Y > max2)
                {
                    max2 = fig2[i].Y;
                }
                if (fig2[i].Y < min2)
                {
                    min2 = fig2[i].Y;
                }
            }
            if (min2 < Ymin)
            {
                Ymin = min2;
            }
            if (max2 > Ymax)
            {
                Ymax = max2;
            }
        }
    }
}

