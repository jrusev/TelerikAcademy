using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ParticleSystem
{
    // Create a ChickenParticle class.
    // The ChickenParticle class moves like a ChaoticParticle,
    // but randomly stops at different positions for several simulation ticks and,
    // for each of those stops, creates (lays) a new ChickenParticle.
    public class ChickenParticle : ChaoticParticle
    {
        private int tickCounter;
        private int ticksToWait = 5;
        private int maxSpeed = 2;
        private int currentGeneration;
        private static int totalChickenParticles = 1;
        private int waitCounter;

        public ChickenParticle(MatrixCoords position, MatrixCoords speed, int currentGeneration = 1)
            : base(position, speed)
        {
            tickCounter = 0;
            waitCounter = 0;
            this.currentGeneration = currentGeneration;
        }

        public override IEnumerable<Particle> Update()
        {
            tickCounter++;
            var newParticles = new List<Particle>();
            //newParticles.Add(this);

            double totalSpeed = Math.Sqrt(this.Speed.Row * this.Speed.Row + this.Speed.Col * this.Speed.Col);
            if (tickCounter > 4 * ChickenParticle.totalChickenParticles && totalSpeed < maxSpeed)
            {
                waitCounter++;
                if (waitCounter > ticksToWait)
                {
                    ChickenParticle.totalChickenParticles++;
                    MatrixCoords initialSpeed = new MatrixCoords(0, 0);
                    var newParticle = new ChickenParticle(this.Position, initialSpeed, ChickenParticle.totalChickenParticles);
                    newParticles.Add(newParticle);

                    tickCounter = 0;
                    waitCounter = 0;
                }
            }
            else
            {
                this.Move();
            }
            
            return newParticles;
        }

        public override char[,] GetImage()
        {
            var genStr = this.currentGeneration.ToString();
            var image = new char[1, genStr.Length];
            for (int col = 0; col < image.GetLength(1); col++)
            {
                image[0, col] = genStr[col];
            }

            return image;
        }
    }
}
