using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;

using Attr;
namespace SnowRain
{
    public class Cylinder
    {

        // Attributes and properties
        public Point3D position = new Point3D();
        public Vector3D rotation;
        public float rot_angle;
        private float[] color;
        public float radius;
        public float height;
        public Cylinder(float[] color)
        {
            this.color = color;
        }

        public Cylinder()
        {
            rot_angle = 0;
        }

        public void Draw()
        {
            var x = 30;
            Gl.glPushMatrix();
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT_AND_DIFFUSE, color);
            Gl.glTranslated(position.x, position.y, position.z);
            Gl.glRotated(rot_angle, rotation.x, rotation.y, rotation.z);
            Glut.glutSolidCylinder( radius, height, 12, 12);
            Gl.glPopMatrix(); 
            float[] MatrixColorOX = { 1, 0, 0, 1 };
            

        }

    }
}

