using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ParticleSystem
{
    // Free particle - does not have its own "engine"
    public class FreeParticle : Particle
    {
        public FreeParticle(MatrixCoords position, MatrixCoords speed)
            : base(position, speed)
        {
        }

        public override char[,] GetImage()
        {
            return new char[,] { { 'f' } };
        }

        public override IEnumerable<Particle> Update()
        {
            return new List<Particle>();
        }
    }
}
