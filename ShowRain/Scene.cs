using System;

namespace SnowRain
{
    public class Scene
    {

        // Associations 
        private Ice unnamed_12;
        private Static_objects statics;
        private Dynamic_objects dynamic;
        public Scene()
        {
            statics = new Static_objects();
            dynamic = new Dynamic_objects();
        }
        public void Draw(float CurTime)
        {
            statics.Draw();
            dynamic.Draw(CurTime);
        }
    }
}

