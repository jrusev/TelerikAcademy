using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ParticleSystem
{
    // Particle emitter.
    // Creates new FreeParticle every ticksToWait.
    public class ParticleEmitter : ChaoticParticle
    {
        private int tickCounter = 0;
        private int ticksToWait = 5;

        public ParticleEmitter(MatrixCoords position, MatrixCoords speed, int currentGeneration = 1)
            : base(position, speed)
        {
        }

        public override IEnumerable<Particle> Update()
        {
            tickCounter++;
            var newParticles = new List<Particle>();

            if (tickCounter > ticksToWait)
            {
                MatrixCoords initialSpeed = new MatrixCoords(1, 1);
                var newParticle = new FreeParticle(this.Position, initialSpeed);
                newParticles.Add(newParticle);

                tickCounter = 0;
            }

            return newParticles;
        }

        public override char[,] GetImage()
        {
            return new char[,] { { 'E' } };
        }
    }
}
