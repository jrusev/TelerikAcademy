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
        private int life;
        public FreeParticle(MatrixCoords position, MatrixCoords speed, int lifeTime)
            : base(position, speed)
        {
            this.life = lifeTime;
        }

        public override char[,] GetImage()
        {
            return new char[,] { { 'f' } };
        }

        public override IEnumerable<Particle> Update()
        {
            this.life--;
            return new List<Particle>();
        }

        public new void Move()
        {
            base.Move();
        }

        public override bool Exists
        {
            get
            {
                return this.life > 0;
            }
        }
    }
}
