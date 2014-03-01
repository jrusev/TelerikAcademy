using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public interface IParticleOperator
    {
        void OperateOn(Particle p);

        void TickEnded();
    }
}
