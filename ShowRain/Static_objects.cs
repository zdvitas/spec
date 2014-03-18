using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowRain
{

    public class Static_objects
    {

        // Attributes and properties
        public List<Static_object> Objects;

        public  Static_objects()
        {
            Objects = new List<Static_object>();
            Objects.Add(new Tower(1));
            Objects.Add(new Tower(-1));
        }

        public void Draw()
        {
            foreach(var obj in Objects)
            {
                obj.Draw();
            }
        }
    }
}

