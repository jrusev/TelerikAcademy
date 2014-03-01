using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ParticleSystem
{
    // Particle emitter.
    // Creates new FreeParticle every ticksToWait.
    public class ParticleEmitter : Particle
    {
        private int tickCounter = 10;
        private int ticksToWait = 10;
        private int lifeTime;

        public ParticleEmitter(MatrixCoords position, MatrixCoords initialSpeed, int lifeTime)
            : base(position, initialSpeed)
        {
            this.lifeTime = lifeTime;
        }

        public override IEnumerable<Particle> Update()
        {
            tickCounter++;
            var newParticles = new List<Particle>();

            if (tickCounter > ticksToWait)
            {
                int angleDegr = Engine.rand.Next(90);
                int speedRow = (int)(this.Speed.Row * Math.Sin(angleDegr * Math.PI / 180));
                int speedCol = (int)(this.Speed.Col * Math.Cos(angleDegr * Math.PI / 180));

                MatrixCoords intialSpeed = new MatrixCoords(speedRow, speedCol);
                var newParticle = new FreeParticle(this.Position, intialSpeed, this.lifeTime);
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
