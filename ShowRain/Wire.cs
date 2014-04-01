using System;
using System.Collections.Generic;
using System.Collections;


namespace SnowRain
{

    public class Wire : Static_object
    {
        
        // Attributes and properties
        public int interpolation = 2;
        public float cur_length = 40;
        public float weigth;
        public Cylinder cy = new Cylinder();

        // Associations 
        private List<Cylinder> cyls = new List<Cylinder>();
       
        public Wire()
        {
            cy.radius = 0.1f;
            cy.height = 40;
            cy.position.y = 20;
            cy.position.x = -20;
            cy.rot_angle = 90;
            cy.rotation.z = 0;
            cy.rotation.y = 1;
        }

        public override void Draw()
        {
            cy.Draw();
            
            return;
        }

    }
}

