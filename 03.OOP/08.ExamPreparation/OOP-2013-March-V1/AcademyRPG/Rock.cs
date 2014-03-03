using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Rock : StaticObject, IResource
    {
        public Rock(int hitPoints, Point position)
            : base(position)
        {
            this.HitPoints = hitPoints;
        }

        public ResourceType Type 
        { 
            get 
            { 
                return ResourceType.Stone; 
            } 
        }

        // The Quantity of the Rock should be half it’s HitPoints
        public int Quantity
        {
            get
            {
                return this.HitPoints / 2;
            }
        }
    }
}