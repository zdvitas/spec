using System;

namespace SnowRain
{
    public class Draw
    {

        // Associations 
        private Scene scene;

        public Draw()
        {
            scene = new Scene();
        }
        public void Do(float curTime,  bool paused)
        {
            scene.Draw(curTime, paused);
        }



    }
}

