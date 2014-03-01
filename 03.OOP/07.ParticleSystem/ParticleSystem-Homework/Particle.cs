using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public class Particle : IRenderable, IAcceleratable
    {
        public MatrixCoords Position
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<Particle> Update()
        {
            throw new NotImplementedException();
        }

        public MatrixCoords GetTopLeft()
        {
            throw new NotImplementedException();
        }

        public char[,] GetImage()
        {
            throw new NotImplementedException();
        }


        public bool Exists
        {
            get { return true; }
        }

        public MatrixCoords Speed
        {
            get { throw new NotImplementedException(); }
        }

        public void Accelerate(MatrixCoords acceleration)
        {
            throw new NotImplementedException();
        }
    }
}
