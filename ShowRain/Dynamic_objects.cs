using System;

namespace SnowRain
{
    public class Dynamic_objects
    {

        // Associations 
        private SPH_Water_System unnamed_6;
        private Snow_System snow;

        public Dynamic_objects()
        {
            snow = new Snow_System();
        }

        public void Draw(float CurTime)
        {
            snow.Draw(CurTime);
        }
    }
}

