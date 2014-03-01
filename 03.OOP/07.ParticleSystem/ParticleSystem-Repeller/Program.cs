using System;

namespace ParticleSystem
{
    class Program
    {
        private const int MaxRows = 60;
        private const int MaxCols = 120;

        // Create a ChaoticParticle class, which is a Particle, randomly changing its movement (Speed).
        static void Main()
        {
            IRenderer renderer = new ConsoleRenderer(MaxRows, MaxCols);
            IParticleOperator particleOperator = new ParticleUpdater();

            MatrixCoords repellerPosition = new MatrixCoords(MaxRows - 10, MaxCols - 10);
            MatrixCoords repellerSpeed = new MatrixCoords(0, 0);
            int repellerGravity = -2; // antigravity
            ParticleRepeller repeller = new ParticleRepeller(repellerPosition, repellerSpeed, repellerGravity);

            FieldEngine engine = new FieldEngine(renderer, particleOperator, repeller);
            engine.AddParticle(repeller);

            MatrixCoords emitterPosition = new MatrixCoords(10, 20);
            MatrixCoords emitterSpeed = new MatrixCoords(10, 10);
            int particleLifeTicks = 20;
            ParticleEmitter emitter = new ParticleEmitter(emitterPosition, emitterSpeed, particleLifeTicks);
            engine.AddParticle(emitter);

            SetConsole();
            engine.Run();
        }

        private static void SetConsole()
        {
            Console.CursorVisible = false;
            try
            {
                // Set console dimensions
                Console.WindowWidth = MaxCols + 1;
                Console.WindowHeight = MaxRows + 1;

                Console.BufferWidth = MaxCols + 1;
                Console.BufferHeight = MaxRows + 1;
            }
            catch (ArgumentOutOfRangeException)
            {

                Console.WriteLine("Cannot set console dimensions!");
                Console.ReadKey(true);
            }
        }
    }
}