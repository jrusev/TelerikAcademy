using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public class ParticleUpdater : IParticleOperator
    {
        public void OperateOn(Particle p)
        {
            // TODO: OperateOn
            p.Update();
        }

        public void TickEnded()
        {
            // TODO: TickEnded
        }
    }
}
