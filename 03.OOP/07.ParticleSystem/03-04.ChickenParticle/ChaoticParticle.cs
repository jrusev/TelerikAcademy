using System;
using System.Diagnostics;

namespace ParticleSystem
{
    // Create a ChaoticParticle class, which is a Particle, randomly changing its movement (Speed).
    public class ChaoticParticle : Particle
    {
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

            int deltaRow = (int)(Engine.rand.Next(3) - this.Speed.Row / 1.5 - 1);
            int deltaCol = (int)(Engine.rand.Next(3) - this.Speed.Col / 1.5 - 1);

            this.Acceleration = new MatrixCoords(this.Acceleration.Row + deltaRow, this.Acceleration.Col + deltaCol);

            if (this.Speed.Row > 5)
            {
                this.Acceleration = new MatrixCoords(-5, this.Acceleration.Col);
            }
            else if (this.Speed.Row < -5)
            {
                this.Acceleration = new MatrixCoords(5, this.Acceleration.Col);
            }

            if (this.Speed.Col > 5)
            {
                this.Acceleration = new MatrixCoords(this.Acceleration.Row, -5);
            }
            else if (this.Speed.Col < -5)
            {
                this.Acceleration = new MatrixCoords(this.Acceleration.Row, 5);
            }

            this.Accelerate(Acceleration);
            base.Move();
            //Debug.WriteLine("accRow = {0}, accCol = {1}", this.Acceleration.Row, this.Acceleration.Col);
            //Debug.WriteLine("spdRow = {0}, spdCol = {1}", this.Speed.Row, this.Speed.Col);
        }

        public override char[,] GetImage()
        {
            return new char[,] { { '*' } };
        }
    }
}
