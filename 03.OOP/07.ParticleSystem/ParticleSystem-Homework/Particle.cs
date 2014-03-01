using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public class Particle : IRenderable, IAcceleratable
    {
        public Particle(MatrixCoords position, MatrixCoords speed)
        {
            // TODO: Particle constructor
            this.Position = position;
            this.Speed = speed;
        }

        public MatrixCoords Position { get; protected set; }

        public virtual IEnumerable<Particle> Update()
        {
            // TODO: Particle Update
            this.Position += this.Speed;
            return new List<Particle>();
        }

        public MatrixCoords GetTopLeft()
        {
            // TODO: GetTopLeft
            return this.Position;
        }

        public char[,] GetImage()
        {
            // TODO: GetImage
            return new char[,] { { '*' } };
        }


        public bool Exists
        {
            get { return true; }
        }

        public MatrixCoords Speed { get; protected set; }

        public void Accelerate(MatrixCoords acceleration)
        {
            // TODO: Accelerate
            this.Speed += acceleration;
        }
    }
}
