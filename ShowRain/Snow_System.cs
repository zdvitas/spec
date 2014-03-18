using System;
using System.Collections.Generic;
using System.Windows;
using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;
using Attr;

namespace SnowRain
{
    public class Snow_System
    {

        private int DisplayListNom = 0;
        // ���������� ������ ��� ��������� ������ ������
        private bool isDisplayList = false;
        // Associations 
        private List<Snow_particle> snows;
        Random rand = new Random();
        Random randPart = new Random();
        Random randSpeed = new Random();

        private const float x = 50;
        private const float y = 30;
        private const float z = 50;

        public Snow_System()
        {
            snows = new List<Snow_particle>();
            CreateDisplayList();
        }

        public Point3D Randomize(float x, float y, float z)
        {
            Point3D Point = new Point3D();
            
            Point.x = (float)randPart.NextDouble() * (x) - (x / 2);
            Point.z = (float)randPart.NextDouble() * (z) - (z / 2);
            Point.y = (float)randPart.NextDouble() + y;
            return Point;
        }

        private void Add(int count)
        {
            for(int i = 0 ; i < count ; i ++)
            {
                snows.Add(new Snow_particle(Randomize(x,y,z) , (float)randSpeed.Next(2,10)));
            }
        }

        private void Update(float CurTime)
        {

            int randCount = rand.Next(1, 40);
            Add(randCount);

            for(int i = 0; i < snows.Count ; i ++)
            {
                snows[i].UpdatePosition(CurTime);
                

                Gl.glPushMatrix();
                // �������� ������ �������
                float size = 9f;

                // ��������� ����������� ������� � ����������� �������
                Gl.glTranslated(snows[i].GetPositionX(), snows[i].GetPositionY(), snows[i].GetPositionZ());
                // ������������ �� � ����������� � �� ��������
                Gl.glScalef(size, size, size);
                // �������� ���������� ������ ��� ��������� ������� �� ���� �������������
                Gl.glCallList(DisplayListNom);
                // ���������� �������
                Gl.glPopMatrix();

                if(snows[i].GetPositionY() < 0)
                {
                    snows.RemoveAt(i);
                }
            }

            
        }

        public void Draw(float CurTime)
        {
            Update(CurTime);
            return;
        }

        private void CreateDisplayList()
        {
            // ��������� ���������� �������
            DisplayListNom = Gl.glGenLists(1);
            float[] Color = { 0.001f, 0.001f, 0.4f, 1 };
            // ������ �������� ������
            Gl.glNewList(DisplayListNom, Gl.GL_COMPILE);
            // Gl.glColor3b(0, 0, 255);
            Gl.glColor3d(0, 0, 255);
            Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK, Gl.GL_AMBIENT_AND_DIFFUSE, Color);
            // ����� ��������� ������������
            try
            {


                Glut.glutSolidSphere(0.01f, 10, 10);
            }
            catch(Exception e)
            {
                int i = 0;
            }
            // ��������� ��������� �������
            Gl.glEndList();

            // ���� - ���������� ������ ������
            isDisplayList = true;
        }
    }
}

