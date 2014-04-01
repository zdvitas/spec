using System;
using Attr;

namespace SnowRain
{
    public class Snow_particle : moveble_particle
    {
        

        private float _size;

        // вектор гравитации 
        private float[] Grav = new float[3];
        // ускорение частицы
        private float[] power = new float[3];

        // набранная скорость
        private float[] speed = new float[3];

        // временной интервал активации частицы
        private float LastTime = 0;


        float x = 30;
        float y = 30;
        float z = 30;

        

        public Snow_particle()
        {
            position.Randomize(x,y,z);
            Grav[0] = 0f;
            Grav[1] = -9.8f;
            Grav[2] = 0f;

            speed[1] = -3f;
        }

        public Snow_particle(Point3D Point, float speedR)
        {
            position = Point;

            Grav[0] = 0f;
            Grav[1] = -9.8f;
            Grav[2] = 0f;

            speed[1] = -speedR;
        }


        public void UpdatePosition(float timeNow)
        {
            LastTime += timeNow;
            float dTime = timeNow;
            for (int a = 0; a < 3; a++)
            {
                position.arr[a] += (speed[a] * dTime + (Grav[a] + power[a]) * dTime * dTime);
                speed[a] += (Grav[a] + power[a]) * dTime;
            }

        }
    }
}

