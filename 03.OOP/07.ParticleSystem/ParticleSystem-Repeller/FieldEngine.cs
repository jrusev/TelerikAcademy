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
                    var freeParticle = particle as FreeParticle;
                    if (freeParticle != null)
                    {
                        double range = this.Range(this.repeller, freeParticle);

                        double forceRow = this.repeller.Gravity * (this.repeller.Position.Row - freeParticle.Position.Row) / range;
                        double forceCol = this.repeller.Gravity * (this.repeller.Position.Col - freeParticle.Position.Col) / range;

                        var acceleration = new MatrixCoords((int)forceRow, (int)forceCol);
                        freeParticle.Accelerate(acceleration);
                        freeParticle.Move();
                    }
                }

                this.particles.RemoveAll(p => !p.Exists);

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

        private double Range(Particle p1, Particle p2)
        {
            int cols = p1.Position.Col - p2.Position.Col;
            int rows = p1.Position.Row - p2.Position.Row;
            return Math.Sqrt(cols * cols + rows * rows);
        }
    }
}
