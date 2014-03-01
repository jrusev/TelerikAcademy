using System;

namespace ParticleSystem
{
    class Program
    {
        static void Main()
        {
            IRenderer renderer = new ConsoleRenderer(40, 80);
            IParticleOperator particleOperator = new ParticleUpdater();         

            Engine engine = new Engine(renderer, particleOperator);

            Particle chaoticParticle = new ChaoticParticle(new MatrixCoords(20, 40), new MatrixCoords(1, 1));
            engine.AddParticle(chaoticParticle);

            engine.Run();
        }
    }
}