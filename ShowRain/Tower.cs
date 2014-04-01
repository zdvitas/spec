using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attr;

namespace SnowRain
{
    public class Tower : Static_object
    {

        // Attributes and properties
        public Point3D position;
        private float[] color = { 1f, 0.3f, 0f, 1 };
        // Associations 
        private Cylinder[] cyls = new Cylinder[2] ;

        public Tower(int index)
        {
            color[0] = index == -1 ? 0 : 0.5f;
            cyls[0] = new Cylinder(color);
            cyls[0].radius = .3f;
            cyls[0].height = 20;
            cyls[0].position.x = 20 * index;
            cyls[0].position.y = 0;
            cyls[0].position.z = 0;
            cyls[0].rot_angle = 90;
            cyls[0].rotation.y = 0;
            cyls[0].rotation.x = -1;
            
        }

        public override void Draw()
        {
            cyls[0].Draw();
        }
    }
}

 