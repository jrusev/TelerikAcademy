using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    // Create a ChaoticParticle class, which is a Particle, randomly changing its movement (Speed).
    public class ChaoticParticle : Particle
    {
        public ChaoticParticle(MatrixCoords position, MatrixCoords speed)
            : base(position, speed)
        {

        }
    }
}
