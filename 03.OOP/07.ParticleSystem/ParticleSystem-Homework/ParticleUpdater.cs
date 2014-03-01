using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

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
            Thread.Sleep(100);
        }
    }
}
