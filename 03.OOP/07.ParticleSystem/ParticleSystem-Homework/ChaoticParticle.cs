using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ParticleSystem
{
    // Create a ChaoticParticle class, which is a Particle, randomly changing its movement (Speed).
    public class ChaoticParticle : Particle
    {
        private readonly Random rand = new Random();

        public ChaoticParticle(MatrixCoords position, MatrixCoords speed)
            : base(position, speed)
        {

        }

        public MatrixCoords Acceleration { get; private set; }

        public MatrixCoords deltaAcceleration { get; private set; }

        protected override void Move()
        {
            // deltaRow and deltaCol will take values from -1 to 1
            //int deltaRow = rand.Next(3) - 1;
            //int deltaCol = rand.Next(3) - 1;

            int deltaRow = (int)(rand.Next(3) - this.Speed.Row / 1.5 - 1);
            int deltaCol = (int)(rand.Next(3) - this.Speed.Col / 1.5 - 1);

            this.Acceleration = new MatrixCoords(this.Acceleration.Row + deltaRow, this.Acceleration.Col + deltaCol);
            this.Accelerate(Acceleration);
            base.Move();
            Debug.WriteLine("accRow = {0}, accCol = {1}", this.Acceleration.Row, this.Acceleration.Col);
            Debug.WriteLine("spdRow = {0}, spdCol = {1}", this.Speed.Row, this.Speed.Col);
        }

        public override char[,] GetImage()
        {
            double angleInDegrees = Math.Atan2(-this.Speed.Row, this.Speed.Col) * 180 / Math.PI;
            int dir = (int)(Math.Round(angleInDegrees / 90, 0));

            char symbol = '*';
            if (dir == 0)
            {
                symbol = '→';
            }
            else if (dir == 1)
            {
                symbol = '↑';
            }
            else if (dir == -1)
            {
                symbol = '↓';
            }
            else if (dir == 2 || dir == -2)
            {
                symbol = '←';
            }

            symbol = '*';
            return new char[,] { { symbol } };
        }
    }
}
