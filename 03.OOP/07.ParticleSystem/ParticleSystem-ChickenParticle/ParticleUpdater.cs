using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public class ParticleUpdater : IParticleOperator
    {
        public IEnumerable<Particle> OperateOn(Particle p)
        {
            // TODO: OperateOn
            return p.Update();
        }

        public void TickEnded()
        {
            // TODO: TickEnded
        }
    }
}
