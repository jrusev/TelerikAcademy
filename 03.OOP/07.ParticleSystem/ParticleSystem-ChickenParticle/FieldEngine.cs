using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace ParticleSystem
{
    public class FieldEngine : Engine
    {
        public ParticleRepeller repeller;

        public FieldEngine(IRenderer renderer, IParticleOperator particleOperator, ParticleRepeller repeller, List<Particle> particles = null)
            : base(renderer, particleOperator, particles)
        {
            this.repeller = repeller;
        }

        public override void Run()
        {
            while (true)
            {
                var newparticles = new List<Particle>();

                foreach (var particle in particles)
                {
                    newparticles.AddRange(particleOperator.OperateOn(particle));
                }

                this.particles.AddRange(newparticles);

                foreach (var particle in this.particles)
                {
                    renderer.EnqueueForRendering(particle);
                }

                particleOperator.TickEnded();

                renderer.RenderAll();
                renderer.ClearQueue();

                //Debug.WriteLine("Thread.Sleep({0})", SleepTimeMs);
                Thread.Sleep(SleepTimeMs);
            }
        }
    }
}
