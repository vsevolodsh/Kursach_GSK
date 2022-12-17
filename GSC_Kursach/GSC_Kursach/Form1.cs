using System.Drawing;
using System.Windows.Forms.Design.Behavior;
using System.Xml.Linq;

namespace GSC_Kursach
{
    public partial class Form1 : Form
    {
        Bitmap myBitmap;
        Graphics g;
        Pen DrawPen = new Pen(Color.Black, 5);
        int PrimitiveType = 0;
        int OperationType = 0;
        Point pictureBox1MousePos = new Point();
        Boolean checkPrim = false;
        Boolean isTmoOperand = false;
        List<PointF> VertexList = new List<PointF>(); //список вершин
        List<Primitive> PrimitiveList = new List<Primitive>(); //список примитивов
        List<Pen> DrawPenList = new List<Pen>(); //список цветов 
        List<int[]> SetQList = new List<int[]>();
        Primitive PrimitiveGeomPreob = new Primitive(); //Примитив над которым происходит геом. преобразование.  
        int[] SetQ = new int[3];
        List<Primitive> PrimitivesForTmo = new List<Primitive>(); //Список  операндов для тмо
        int currentTmoOperand = 0;
        int indexTmoOperand = -1;

        public Form1()
        {
            InitializeComponent();
            myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(myBitmap);

        }
        private void comboBoxPrimitive_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrimitiveType = comboBoxPrimitive.SelectedIndex;
        }
        private void comboBoxOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            OperationType = comboBoxOperation.SelectedIndex;
        }

        private void comboBoxTMO_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxTMO.SelectedIndex)
            {
                case 0:
                    SetQ[0] = 3; SetQ[1] = 3; SetQ[2] = 3;
                    break;
                case 1:
                    SetQ[0] = 1; SetQ[1] = 1; SetQ[2] = 2;
                    break;

            }
        }

        private void comboBoxColour_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxColour.SelectedIndex) // выбор цвета
            {
                case 0:
                    DrawPen.Color = Color.Black;
                    break;
                case 1:
                    DrawPen.Color = Color.Red;
                    break;
                case 2:
                    DrawPen.Color = Color.Green;
                    break;
                case 3:
                    DrawPen.Color = Color.Blue;
                    break;
            }

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = myBitmap;
            g.Clear(Color.White);
            PrimitiveList.Clear();
            DrawPenList.Clear();
            VertexList.Clear();
            PrimitivesForTmo.Clear();
            currentTmoOperand = 0;
            indexTmoOperand = -1;
        }

        // Обработчик события
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1MousePos = e.Location;
            if (OperationType == 0) //Рисование
            {
                if (PrimitiveType == 0) // Линия
                {

                    VertexList.Add(new Point() { X = e.X, Y = e.Y });
                    if (VertexList.Count == 2)
                    {
                        List<PointF> tempVL = new List<PointF>(VertexList); // Создаем буффер список точек, чтобы при очистке VertexList не очищались элементы PrimitiveList
                        Line line = new Line(g, DrawPen, tempVL);
                        Pen pen = new Pen(DrawPen.Color, 5);
                        PrimitiveList.Add(line);
                        DrawPenList.Add(pen);
                        line.drawLine(DrawPen);
                        VertexList.Clear();
                    }
                }
                if (PrimitiveType == 1) // Кубический сплайн
                {
                    VertexList.Add(new Point() { X = e.X, Y = e.Y });
                    g.DrawEllipse(DrawPen, e.X - 2, e.Y - 2, 5, 5);
                    if (VertexList.Count == 4)
                    {
                        List<PointF> tempVL = new List<PointF>(VertexList); // Создаем буффер список точек, чтобы при очистке VertexList не очищались элементы PrimitiveList
                        Er er = new Er(g, DrawPen, tempVL);
                        Pen pen = new Pen(DrawPen.Color, 5);
                        PrimitiveList.Add(er);
                        DrawPenList.Add(pen); // Запоминаем цвет конкретной фигуры, чтобы при перерисовки присвоеть фигуре её цвет
                        er.DrawCubeSpline(DrawPen);
                        VertexList.Clear();
                    }

                }
                if (PrimitiveType == 2) // Фигура 4
                {
                    List<PointF> tempVL = new List<PointF>(); // Создаем буффер список точек, чтобы при очистке VertexList не очищались элементы PrimitiveList
                    Pen pen = new Pen(DrawPen.Color, 5);
                    Fg4 fg4 = new Fg4(g, DrawPen, tempVL);
                    fg4.setPoints(new Point() { X = e.X, Y = e.Y });
                    DrawPenList.Add(pen); // Запоминаем цвет конкретной фигуры, чтобы при перерисовки присвоеть фигуре её цвет
                    PrimitiveList.Add(fg4);
                    fg4.fillPrim(DrawPen);

                }
                if (PrimitiveType == 3) // Стрелка 2
                {
                    List<PointF> tempVL = new List<PointF>(); // Создаем буффер список точек, чтобы при очистке VertexList не очищались элементы PrimitiveList
                    Pen pen = new Pen(DrawPen.Color, 5);
                    Str2 str2 = new Str2(g, DrawPen, tempVL);
                    str2.setPoints(new Point() { X = e.X, Y = e.Y });
                    PrimitiveList.Add(str2);
                    DrawPenList.Add(pen); // Запоминаем цвет конкретной фигуры, чтобы при перерисовки присвоеть фигуре её цвет
                    str2.fillPrim(DrawPen);

                }
            }
            if (OperationType == 1) // Геометр. преобразования 
            {
                if (e.Button == MouseButtons.Left)
                {
                    for (int i = 0; i < PrimitiveList.Count; i++)
                    {
                        if (PrimitiveList[i].ThisPgn(e.X, e.Y)) // выбор фигуры
                        {
                            isTmoOperand = false;
                            PrimitiveGeomPreob = PrimitiveList[i];
                            g.DrawEllipse(new Pen(Color.Blue), e.X - 2, e.Y - 2, 5, 5);
                            checkPrim = true;
                        }
                    }
                    for (int i = 0; i < PrimitivesForTmo.Count; i++)
                    {
                        if (PrimitivesForTmo[i].ThisPgn(e.X, e.Y))
                        {
                            isTmoOperand = true;
                            currentTmoOperand = i;
                            g.DrawEllipse(new Pen(Color.Blue), e.X - 2, e.Y - 2, 5, 5);
                            checkPrim = true;
                        }
                    }
                }
                if (e.Button == MouseButtons.Right) // прорисовка линии для отражения
                {
                    VertexList.Add(new Point() { X = e.X, Y = e.Y });
                    if (VertexList.Count == 2)
                    {
                        Line line = new Line(g, new Pen(Color.Yellow, 5), VertexList);
                        line.drawLine(line.DrawPen);
                    }
                }

            }
            if (OperationType == 2) // TMO
            {
                for (int i = 0; i < PrimitiveList.Count; i++)
                {
                    if (PrimitiveList[i].ThisPgn(e.X, e.Y)) // выбор фигуры
                    {
                        PrimitivesForTmo.Add(PrimitiveList[i]);
                        //  currentTmoOperand++;
                        indexTmoOperand++;
                        PrimitiveList.Remove(PrimitiveList[i]);
                        DrawPenList.RemoveAt(i); // Удаляем из списка цветов цвет операнда тмо
                        g.DrawEllipse(new Pen(Color.Blue), e.X - 2, e.Y - 2, 5, 5);
                        checkPrim = true;
                    }
                }
            }
            pictureBox1.Image = myBitmap;
        }

        private void buttonTMO_Click(object sender, EventArgs e) //выполнить тмо
        {
            if (OperationType == 2 && checkPrim)
            {
                int[] buffSetQ = new int[3] { SetQ[0], SetQ[1], SetQ[2] };
                SetQList.Add(buffSetQ);
                Tmo tmo = new Tmo(g, DrawPen, PrimitivesForTmo[indexTmoOperand - 1].VertexList, PrimitivesForTmo[indexTmoOperand].VertexList);
                PrimitiveList.Add(tmo);
                Pen pen = new Pen(DrawPen.Color, 5);
                DrawPenList.Add(pen); // Запоминаем цвет конкретной фигуры, чтобы при перерисовки присвоеть фигуре её цвет
                repainting();
                // PrimitiveList.Remove(tmo);
                pictureBox1.Image = myBitmap;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) //перемещение фигуры
        {
            if (e.Button == MouseButtons.Left)
            {
                if (OperationType == 1 && checkPrim)
                {
                    if (isTmoOperand)
                    {
                        int secondTmoOperand = findSecondTmoOperand();
                        PrimitivesForTmo[currentTmoOperand].Move(e.X - pictureBox1MousePos.X, e.Y - pictureBox1MousePos.Y);
                        PrimitivesForTmo[secondTmoOperand].Move(e.X - pictureBox1MousePos.X, e.Y - pictureBox1MousePos.Y);
                        repainting();
                        pictureBox1.Image = myBitmap;
                        pictureBox1MousePos = e.Location;
                    }
                    else
                    {
                        PrimitiveGeomPreob.Move(e.X - pictureBox1MousePos.X, e.Y - pictureBox1MousePos.Y);
                        repainting();
                        pictureBox1.Image = myBitmap;
                        pictureBox1MousePos = e.Location;
                    }
                }
            }
        }

        private void buttonMirror_Click(object sender, EventArgs e) //отражение фигуры
        {
            if (OperationType == 1 && checkPrim)
            {
                if (isTmoOperand)
                {
                    int secondTmoOperand = findSecondTmoOperand();
                    PrimitivesForTmo[currentTmoOperand].mirror(VertexList[0].Y);
                    PrimitivesForTmo[secondTmoOperand].mirror(VertexList[0].Y);
                    VertexList.Clear();
                    repainting();
                }
                else
                {
                    PrimitiveGeomPreob.mirror(VertexList[0].Y);
                    VertexList.Clear();
                    repainting();
                }
            }
            pictureBox1.Image = myBitmap;
        }

        private void buttonTurn_Click(object sender, EventArgs e) //поворот фигуры
        {
            if (OperationType == 1 && checkPrim)
            {
                if (isTmoOperand)
                {
                    int secondTmoOperand = findSecondTmoOperand();
                    Tmo tmo = new Tmo(g, DrawPen, PrimitivesForTmo[currentTmoOperand].VertexList, PrimitivesForTmo[secondTmoOperand].VertexList);
                    PointF center = tmo.findCenterTmo();
                    PrimitivesForTmo[currentTmoOperand].Rotate(trackBarTurn.Value, center, true);
                    PrimitivesForTmo[secondTmoOperand].Rotate(trackBarTurn.Value, center, true);
                    // PrimitiveList.Add(tmo);
                    repainting();
                    //PrimitiveList.Remove(tmo);
                    pictureBox1.Image = myBitmap;
                }
                else
                {
                    PrimitiveGeomPreob.Rotate(trackBarTurn.Value, new PointF(), false);
                    repainting();
                    pictureBox1.Image = myBitmap;
                }
            }
        }

        private void trackBarTurn_Scroll(object sender, EventArgs e)
        {
            labelValueOfAngel.Text = String.Format("Угол поворота: {0}", trackBarTurn.Value);
        }

        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e) // масштабирование фигуры по Х
        {
            if (OperationType == 1 && checkPrim)
            {
                if (isTmoOperand)
                {
                    int secondTmoOperand = findSecondTmoOperand();
                    Tmo tmo = new Tmo(g, DrawPen, PrimitivesForTmo[currentTmoOperand].VertexList, PrimitivesForTmo[secondTmoOperand].VertexList);
                    PointF center = tmo.findCenterTmo();
                    PrimitivesForTmo[currentTmoOperand].Scale(e, center, true);
                    PrimitivesForTmo[secondTmoOperand].Scale(e, center, true);
                    // PrimitiveList.Add(tmo);
                    repainting();
                    //  PrimitiveList.Remove(tmo);
                    pictureBox1.Image = myBitmap;
                }
                else
                {
                    PrimitiveGeomPreob.Scale(e, new PointF(), false);
                    repainting(); // перерисовка
                    pictureBox1.Image = myBitmap;
                }
            }
        }

        private void repainting() //перерисовка всех фигур
        {
            g.Clear(Color.White);
            int j = 0;
            for (int i = 0; i < PrimitiveList.Count; i++)
            {
                if (PrimitiveList[i] is Line)
                {
                    Line line = (Line)PrimitiveList[i];
                    line.drawLine(DrawPenList[i]);
                }
                else if (PrimitiveList[i] is Er)
                {
                    Er er = (Er)PrimitiveList[i];
                    er.DrawCubeSpline(DrawPenList[i]);
                }
                else if (PrimitiveList[i] is Tmo)
                {
                    Tmo tmo = (Tmo)PrimitiveList[i];
                    //tmo.setSetQ(SetQList[i]);
                    tmo.makeTMO(SetQList[j]);
                    j++;
                }
                else
                {
                    PrimitiveList[i].fillPrim(DrawPenList[i]);
                }
            }

        }

        private int findSecondTmoOperand()
        {
            if (currentTmoOperand % 2 == 0)
            {
                return currentTmoOperand + 1;
            }
            else
            {
                return currentTmoOperand - 1;
            }
        }


    }

}