using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public class ParticleRepeller : Particle
    {
        public ParticleRepeller(MatrixCoords position, MatrixCoords speed, int gravity)
            : base(position, speed)
        {
            this.Gravity = gravity;
        }

        public int Gravity { get; private set; }

        public override char[,] GetImage()
        {
            return new char[,] { { 'R' } };
        }
    }
}