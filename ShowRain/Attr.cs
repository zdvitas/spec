using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Attr
{
    public struct Vector3D
    {
        public float x , y, z ;
        

    }
    public class Point3D
    {
        
        public float[] arr = new float[3];

        public Point3D()
        {
            for(int i = 0; i < 0; i++)
            {
                arr[i] = 0;
            }
        }

        public float x
        {
            get
            {
                return arr[0];
            }
            set
            {
                arr[0] = value;
            }
        }



        public float y
        {
            get
            {
                return arr[1];
            }
            set
            {
                arr[1] = value;
            }
        }


        public float z
        {
            get
            {
                return arr[2];
            }
            set
            {
                arr[2] = value;
            }
        } 
  

        public void Randomize(float x , float y, float z)
        {
            var rand = new Random();
            this.x = (float)rand.NextDouble() * (x ) - (x / 2);
            this.z = (float)rand.NextDouble() * (z) - (z / 2);
            this.y = (float)rand.NextDouble() + y;
            
        }

    }
}
