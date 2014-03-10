using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

// для работы с библиотекой OpenGL 
using Tao.OpenGl;
// для работы с библиотекой FreeGLUT 
using Tao.FreeGlut;
// для работы с элементом управления SimpleOpenGLControl 
using Tao.Platform.Windows;

namespace ShowRain
{
    public partial class Form1 : Form
    {

        Camera cam = new Camera();

        public Form1()
        {
            InitializeComponent();
            AnT.InitializeContexts();
        }


        private void InitGL()
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);

            Gl.glClearColor(255, 255, 255, 1);

            Gl.glViewport(0, 0, AnT.Width, AnT.Height);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            Glu.gluPerspective(45, (float)AnT.Width / (float)AnT.Height, 0.1, 200);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);

            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
            Gl.glHint(Gl.GL_LINE_SMOOTH_HINT, Gl.GL_NICEST);
            Gl.glEnable(Gl.GL_BLEND);
            Gl.glEnable(Gl.GL_LINE_SMOOTH);
            Gl.glLineWidth(1.0f);

            cam.Position_Camera(0, 6, -15, 0, 3, 0, 0, 1, 0); //Вот тут в инициализации
            //укажем начальную позицию камеры,взгляда и вертикального вектора.
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitGL();
        }


        private void Draw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glLoadIdentity();
            Gl.glColor3i(255, 0, 0);

            cam.Look(); //Обновляем взгляд камеры

            Gl.glPushMatrix();

            DrawGrid(30, 1);//Нарисуем сетку

            Gl.glPopMatrix();

            Gl.glFlush();

            AnT.Invalidate();
        }


        private void DrawGrid(int x, float quad_size)
        {
            float[] MatrixColorOX = { 1, 0, 0, 1 };
            float[] MatrixColorOY = { 0, 1, 0, 1 };
            float[] MatrixColorOZ = { 0, 0, 1, 1 };
            float[] MatrixOXOYColor = { 0, 0, 1, 1 };
            //x - количество или длина сетки, quad_size - размер клетки
            Gl.glPushMatrix(); //Рисуем оси координат, цвет объявлен в самом начале
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT_AND_DIFFUSE, MatrixColorOX);
            Gl.glTranslated((-x * 2) / 2, 0, 0);
            Gl.glRotated(90, 0, 1, 0);
            Glut.glutSolidCylinder(0.02, x * 2, 12, 12);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT_AND_DIFFUSE, MatrixColorOZ);
            Gl.glTranslated(0, 0, (-x * 2) / 2);
            Glut.glutSolidCylinder(0.02, x * 2, 12, 12);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT_AND_DIFFUSE, MatrixColorOY);
            Gl.glTranslated(0, x / 2, 0);
            Gl.glRotated(90, 1, 0, 0);
            Glut.glutSolidCylinder(0.02, x, 12, 12);
            Gl.glPopMatrix();

            Gl.glBegin(Gl.GL_LINES);

            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT_AND_DIFFUSE, MatrixOXOYColor);

            // Рисуем сетку 1х1 вдоль осей
            for (float i = -x; i <= x; i += 1)
            {
                Gl.glBegin(Gl.GL_LINES);
                // Ось Х
                Gl.glVertex3f(-x * quad_size, 0, i * quad_size);
                Gl.glVertex3f(x * quad_size, 0, i * quad_size);

                // Ось Z
                Gl.glVertex3f(i * quad_size, 0, -x * quad_size);
                Gl.glVertex3f(i * quad_size, 0, x * quad_size);
                Gl.glEnd();
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        bool mouseRotate, mouseMove = false;
        int myMouseYcoord, myMouseXcoord, myMouseXcoordVar, myMouseYcoordVar;
        float rot_cam_X;

        private void AnT_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                mouseRotate = true; //Если нажата левая кнопка мыши

            if (e.Button == MouseButtons.Middle)
                mouseMove = true; //Если нажата средняя кнопка мыши

            myMouseYcoord = e.X; //Передаем в нашу глобальную переменную позицию мыши по Х
            myMouseXcoord = e.Y;
        }

        private void AnT_MouseUp(object sender, MouseEventArgs e)
        {
            mouseRotate = false;
            mouseMove = false;
        }

        private void AnT_MouseMove(object sender, MouseEventArgs e)
        {
            myMouseXcoordVar = e.Y;
            myMouseYcoordVar = e.X;
        }


        private void mouse_Events()
        {
            if (mouseRotate == true) //Если нажата левая кнопка мыши
            {
                AnT.Cursor = System.Windows.Forms.Cursors.SizeAll; //меняем указатель

                cam.Rotate_Position((float)(myMouseYcoordVar - myMouseYcoord), 0, 1, 0); //крутим камеру, в моем случае это от 3го лица

                rot_cam_X = rot_cam_X + (myMouseXcoordVar - myMouseXcoord);
                if ((rot_cam_X > -40) && (rot_cam_X < 40))
                    cam.upDown(((float)(myMouseXcoordVar - myMouseXcoord)) / 10);

                myMouseYcoord = myMouseYcoordVar;
                myMouseXcoord = myMouseXcoordVar;
            }
            else
            {
                if (mouseMove == true)
                {
                    AnT.Cursor = System.Windows.Forms.Cursors.SizeAll;

                    cam.Move_Camera((float)(myMouseXcoordVar - myMouseXcoord) / 50);
                    cam.Strafe(-((float)(myMouseYcoordVar - myMouseYcoord) / 50));

                    myMouseYcoord = myMouseYcoordVar;
                    myMouseXcoord = myMouseXcoordVar;

                }
                else
                {
                    AnT.Cursor = System.Windows.Forms.Cursors.Default;//возвращаем курсор
                };
            };
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            mouse_Events();
            cam.update();
            Draw();
        }
        
    }
}
