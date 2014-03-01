using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    // Implement a ParticleRepeller class. A ParticleRepeller is a Particle, which pushes other particles away from it
    // (i.e. accelerates them in a direction, opposite of the direction in which the repeller is).
    // The repeller has an effect only on particles within a certain radius (see Euclidean distance).
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