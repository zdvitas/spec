using System;
using System.Collections.Generic;
using System.Text;

using Attr;

namespace SnowRain
{
    public class Particle
    {
        public Point3D position = new Point3D();

        public float GetPositionX()
        {
            return position.x;
        }
        public float GetPositionY()
        {
            return position.y;
        }
        public float GetPositionZ()
        {
            return position.z;
        }
    }
}
