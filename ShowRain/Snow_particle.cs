using System;
using Attr;

namespace SnowRain
{
    public class Snow_particle : moveble_particle
    {
        private float _size;
        // время жизни
        private float _lifeTime;

        //private float CurTime = 0;

        // вектор гравитации 
        private float[] Grav = new float[3];
        // ускорение частицы
        private float[] power = new float[3];
        // коэфичент затухания силы
        private float attenuation;

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
            Grav[1] = -0f;
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

            // орпределяем разницу во времени прошедшую с послднего обновления
            // позиции частицы. (ведь таймер может быть не фиксированный)
            LastTime += timeNow;
            float dTime = timeNow;
            _lifeTime -= dTime;

            
            

            // перерасчитываем ускорение, движущее частицу, с учетом затухания
            for (int a = 0; a < 3; a++)
            {

                if (power[a] > 0)
                {
                    power[a] -= attenuation * dTime;

                    if (power[a] <= 0)
                        power[a] = 0;
                }

                // перерасчитываем позицию частицы с учетом гравитации, вектора ускорения и прощедший промежуток времени
                position.arr[a] += (speed[a] * dTime + (Grav[a] + power[a]) * dTime * dTime);

                // обновляем скорость частицы
                speed[a] += (Grav[a] + power[a]) * dTime;
            }

        }
    }
}

