using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace ParticleSystem
{
    public class Engine
    {
        private const int SleepTimeMs = 500;

        private IParticleOperator particleOperator;

        private List<Particle> particles;

        private IRenderer renderer;

        public Engine(IRenderer renderer, IParticleOperator particleOperator, List<Particle> particles = null)
        {
            this.renderer = renderer;
            this.particleOperator = particleOperator;

            if (particles != null)
            {
                this.particles = particles;
            }
            else
            {
                this.particles = new List<Particle>();
            }
        }

        public void AddParticle(Particle p)
        {
            this.particles.Add(p);
        }

        public void Run()
        {
            while (true)
            {
                foreach (var particle in particles)
                {
                    particleOperator.OperateOn(particle);
                }

                foreach (var particle in this.particles)
                {
                    renderer.EnqueueForRendering(particle);
                }

                particleOperator.TickEnded();

                renderer.RenderAll();
                renderer.ClearQueue();

                Debug.WriteLine("Thread.Sleep({0})", SleepTimeMs);
                Thread.Sleep(SleepTimeMs);
            }
        }
    }
}
