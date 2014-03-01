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
        protected int sleepTimeMs;

        protected IParticleOperator particleOperator;

        protected List<Particle> particles;

        protected IRenderer renderer;

        public static readonly Random rand = new Random();

        public Engine(IRenderer renderer, IParticleOperator particleOperator, int sleepTimeMs, List<Particle> particles = null)
        {
            this.renderer = renderer;
            this.particleOperator = particleOperator;
            this.sleepTimeMs = sleepTimeMs;

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

        public virtual void Run()
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
                Thread.Sleep(sleepTimeMs);
            }
        }
    }
}
