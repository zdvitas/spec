using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnowRain;
using Attr;

namespace ShowRain
{
    class Wire_part : Cylinder
    {
        public float length; // Длина части
        private Point3D position; // позиция левого конца одного отрезка провода
        private float angle; // угол 
        public Wire_part()
        {
            
        }

        public Wire_part(Point3D pos , float ang, float length)
        {
            position = pos;
            angle = ang;
            this.length = length;
        }
    }
}
