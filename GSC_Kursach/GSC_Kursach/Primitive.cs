using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GSC_Kursach
{
    internal class Primitive
    {

        public Graphics g;
        public Pen DrawPen = new Pen(Color.Black, 1);
        public List<PointF> VertexList = new List<PointF>();

        public Primitive(Graphics g, Pen DrawPen, List<PointF> VertexList)
        {
            this.g = g;
            this.DrawPen = DrawPen;
            this.VertexList = VertexList;
        }

        public Primitive() { }

        public Primitive(Graphics g, Pen drawPen)
        {
            this.g = g;
            DrawPen = drawPen;
        }

        public void setDrawPen(Pen pen)
        {
            DrawPen = pen;
        }

        public Pen getDrawPen()
        {
            return DrawPen;
        }

        public List<PointF> getVertexList()
        {
            return VertexList;
        }

        public void fillPrim(Pen DrawPen1)
        {
            float Ymin, Ymax;
            int Y;
            List<float> Xb = new List<float>();
            int k = 0;
            YminMax(out Ymin, out Ymax); // Поиск Y минимум и Y максимум
            for (Y = (int)Ymin; Y <= Ymax; Y++)
            {
                Xb.Clear();
                for (int i = 0; i < VertexList.Count - 1; i++)
                {
                    if (i < VertexList.Count)
                        k = i + 1;

                    else
                    {
                        k = 1;
                    }
                    if ((VertexList[i].Y < Y && VertexList[k].Y >= Y) || (VertexList[i].Y >= Y && VertexList[k].Y < Y))
                    {
                        Xb.Add((VertexList[i].X * VertexList[k].Y - VertexList[k].X * VertexList[i].Y - Y * (VertexList[i].X - VertexList[k].X)) / (VertexList[k].Y - VertexList[i].Y));
                    }
                }
                if ((VertexList[k].Y < Y && VertexList[0].Y >= Y) || (VertexList[k].Y >= Y && VertexList[0].Y < Y))
                {
                    Xb.Add((VertexList[k].X * VertexList[0].Y - VertexList[0].X * VertexList[k].Y - Y * (VertexList[k].X - VertexList[0].X)) / (VertexList[0].Y - VertexList[k].Y));
                }
                Xb.Sort();

                //Закрашивание многоугольника 
                for (int i = 0; i + 1 < Xb.Count; i += 2)
                {
                    g.DrawLine(DrawPen1, new PointF(Xb[i], Y), new PointF(Xb[i + 1], Y));
                }
            }
        }




        //Сортировка Y
        private void YminMax(out float min, out float max)
        {
            min = max = VertexList[0].Y;
            for (int i = 1; i < VertexList.Count; i++)
            {
                float curY = VertexList[i].Y;
                if (curY > max)
                {
                    max = curY;
                }
                if (curY < min)
                {
                    min = curY;
                }
            }
        }

        public bool ThisPgn(int mX, int mY)
        {
            int n = VertexList.Count() - 1, k, m = 0;
            PointF Pi, Pk; double x;
            for (int i = 0; i <= n; i++)
            {
                if (i < n) k = i + 1; else k = 0;
                Pi = VertexList[i]; Pk = VertexList[k];
                if ((Pi.Y < mY) & (Pk.Y >= mY) | (Pi.Y >= mY) & (Pk.Y < mY))
                    if ((mY - Pi.Y) * (Pk.X - Pi.X) / (Pk.Y - Pi.Y) + Pi.X < mX) m++;
            }
            if (this is Line)
            {
                if (m % 2 == 0 && m != 0) return true;
            }
            else
            {
                if (m % 2 == 1) return true;
            }
            return false;
        }

        

        //public void Move(float dx, float dy)
        //{
        //    List<Vertex3> vertex3List = vertexToVertex3();
        //    float[,] matrix = {
        //      {1,  0, 0 },
        //      { 0, 1, 0 },
        //      { dx,  dy, 1 }
        //    };
        //    for (int i = 0; i < vertex3List.Count; i++)
        //        vertex3List[i] = Matrix_1x3_3x3(vertex3List[i], matrix);
        //    for (int i = 0; i < vertex3List.Count; i++)
        //        VertexList[i] = new PointF(vertex3List[i].X, vertex3List[i].Y);
            

        //}

        //public void Rotate(int angle, PointF pRotate, bool isTmo)
        //{
        //    List<Vertex3> vertex3List = vertexToVertex3();
        //    if (!isTmo)
        //    {
        //        pRotate = findCenter();  // центр фигуры
        //    }
        //    double angleRadian = angle * Math.PI / 180; //переводим угол в радианы

        //    float[,] toCenter = {
        //      {1,  0, 0 },
        //      { 0, 1, 0 },
        //      { -pRotate.X,  -pRotate.Y, 1 }

        //    };
        //    for (int i = 0; i < vertex3List.Count; i++)
        //        vertex3List[i] = Matrix_1x3_3x3(vertex3List[i], toCenter);
            

        //    float[,] matrix = {
        //      {(float) Math.Cos(angleRadian), (float) Math.Sin(angleRadian), 0.0f},
        //       {-(float) Math.Sin(angleRadian), (float) Math.Cos(angleRadian), 0.0f},
        //       {0, 0, 1}
        //    };

        //    for (int i = 0; i < vertex3List.Count; i++)
        //        vertex3List[i] = Matrix_1x3_3x3(vertex3List[i], matrix);

        //    float[,] fromCenter = {
        //      {1,  0, 0 },
        //      { 0, 1, 0 },
        //      { pRotate.X,  pRotate.Y, 1 }
        //    };

        //    for (int i = 0; i < vertex3List.Count; i++)
        //        vertex3List[i] = Matrix_1x3_3x3(vertex3List[i], fromCenter);
        //    for (int i = 0; i < vertex3List.Count; i++)
        //        VertexList[i] = new PointF(vertex3List[i].X, vertex3List[i].Y);
        //}

        //public void Scale(MouseEventArgs eventMouse, PointF center, bool isTmo)
        //{
        //    List<Vertex3> vertex3List = vertexToVertex3();
        //    if (!isTmo)
        //    {
        //        center = findCenter();  // центр фигуры
        //    }
        //    float sx = 1;
        //    if (eventMouse.Delta > 0)
        //    {
        //        sx = 1.1f;
        //    }
        //    else if (eventMouse.Delta < 0)
        //    {
        //        sx = 0.9f;
        //    }

        //    float[,] matrix = {
        //      {sx,  0, 0 },
        //      { 0, 1, 0 },
        //      { 0,  0, 1 }
        //    };
        //    float[,] toCenter = {
        //      {1,  0, 0 },
        //      { 0, 1, 0 },
        //      { -center.X,  -center.Y, 1 }
        //    };

        //    for (int i = 0; i < vertex3List.Count; i++)
        //        vertex3List[i] = Matrix_1x3_3x3(vertex3List[i], toCenter);

        //    for (int i = 0; i < vertex3List.Count; i++)
        //        vertex3List[i] = Matrix_1x3_3x3(vertex3List[i], matrix);

        //    float[,] fromCenter = {
        //      {1,  0, 0 },
        //      { 0, 1, 0 },
        //      { center.X,  center.Y, 1 }
        //    };

        //    for (int i = 0; i < vertex3List.Count; i++)
        //        vertex3List[i] = Matrix_1x3_3x3(vertex3List[i], fromCenter);
        //    for (int i = 0; i < vertex3List.Count; i++)
        //        VertexList[i] = new PointF(vertex3List[i].X, vertex3List[i].Y);
        //}

        //public void mirror(float y)
        //{
        //    List<Vertex3> vertex3List = vertexToVertex3();

        //    float[,] toCenter = {
        //      {1,  0, 0 },
        //      { 0, 1, 0 },
        //      { -y,  -y, 1 }
        //    };

        //    for (int i = 0; i < vertex3List.Count; i++)
        //        vertex3List[i] = Matrix_1x3_3x3(vertex3List[i], toCenter);

        //    float[,] matrix = {
        //      {1,  0, 0 },
        //      { 0, -1, 0 },
        //      { 0,  0, 1 }
        //    };
        //    for (int i = 0; i < vertex3List.Count; i++)
        //        vertex3List[i] = Matrix_1x3_3x3(vertex3List[i], matrix);

        //    float[,] fromCenter = {
        //      {1,  0, 0 },
        //      { 0, 1, 0 },
        //      { y,  y, 1 }
        //    };

        //    for (int i = 0; i < vertex3List.Count; i++)
        //        vertex3List[i] = Matrix_1x3_3x3(vertex3List[i], fromCenter);
        //    for (int i = 0; i < vertex3List.Count; i++)
        //        VertexList[i] = new PointF(vertex3List[i].X, vertex3List[i].Y);
        //}

        //public static Vertex3 Matrix_1x3_3x3(Vertex3 Vertex, float[,] matrix3X3)
        //{
        //    Vertex3 newVertex = new Vertex3();
        //    newVertex.X = Vertex.X * matrix3X3[0, 0] + Vertex.Y * matrix3X3[1, 0] + Vertex.V * matrix3X3[2, 0];
        //    newVertex.Y = Vertex.X * matrix3X3[0, 1] + Vertex.Y * matrix3X3[1, 1] + Vertex.V * matrix3X3[2, 1];
        //    newVertex.V = Vertex.X * matrix3X3[0, 2] + Vertex.Y * matrix3X3[1, 2] + Vertex.V * matrix3X3[2, 2];
        //    return newVertex;
        //}
        //public List<Vertex3> vertexToVertex3()
        //{
        //    List<Vertex3> vertex3List = new List<Vertex3>();
        //    for (int i = 0; i < VertexList.Count; i++)
        //    {
        //        vertex3List.Add(new Vertex3(VertexList[i].X, VertexList[i].Y));
        //    }
        //    return vertex3List;
        //}

        public PointF findCenter()
        {
            PointF center = new PointF();
            float Xcenter = 0, Ycenter = 0;
            for (int i = 0; i < VertexList.Count; i++)
            {
                Xcenter += VertexList[i].X;
                Ycenter += VertexList[i].Y;
            }
            center.X = Xcenter / VertexList.Count;
            center.Y = Ycenter / VertexList.Count;
            return center;
        }

        public void Move(int dx, int dy)
        {
            PointF newVertex = new PointF();
            for (int i = 0; i < VertexList.Count; i++)
            {
                newVertex.X = VertexList[i].X + dx;
                newVertex.Y = VertexList[i].Y + dy;
                VertexList[i] = newVertex;
            }
        }

        public void Rotate(int angle, PointF pRotate, Boolean isTmo)
        {

            double angleRadian = angle * Math.PI / 180; //переводим угол в радианты
            if (!isTmo)
            {
                pRotate = findCenter();  // центр фигуры
            }
            PointF newVertex = new PointF();
            for (int j = 0; j < VertexList.Count; j++)
            {

                newVertex.X = ((float)((VertexList[j].X - pRotate.X) * Math.Cos(angleRadian) - (VertexList[j].Y - pRotate.Y) * Math.Sin(angleRadian) + pRotate.X));
                newVertex.Y = ((float)((VertexList[j].X - pRotate.X) * Math.Sin(angleRadian) + (VertexList[j].Y - pRotate.Y) * Math.Cos(angleRadian) + pRotate.Y));
                VertexList[j] = newVertex;


            }
        }

        public void Scale(MouseEventArgs e, PointF pCenter, Boolean isTmo)
        {
            if (!isTmo)
            {
                pCenter = findCenter();  // центр фигуры
            }
            PointF newVertex = new PointF();
            for (int i = 0; i < VertexList.Count; i++)
            {
                PointF vec = new PointF(VertexList[i].X - pCenter.X, VertexList[i].Y - pCenter.Y);
                if (e.Delta > 0)
                {
                    newVertex.X = pCenter.X + (float)1.1 * vec.X;
                    newVertex.Y = VertexList[i].Y;
                }
                else if (e.Delta < 0)
                {
                    newVertex.X = pCenter.X + (float)0.9 * vec.X;
                    newVertex.Y = VertexList[i].Y;
                }
                VertexList[i] = newVertex;
            }
        }

        public void mirror(float y)
        {
            PointF newVertex = new PointF();
            for (int i = 0; i < VertexList.Count; i++)
            {
                newVertex.X = VertexList[i].X;
                newVertex.Y = 2 * y - VertexList[i].Y;
                VertexList[i] = newVertex;
            }
        }
    }
}

