using System;

namespace ParticleSystem
{
    class Program
    {
        private const int MaxRows = 40;
        private const int MaxCols = 80;

        // Create a ChickenParticle class.
        // The ChickenParticle class moves like a ChaoticParticle,
        // but randomly stops at different positions for several simulation ticks and,
        // for each of those stops, creates (lays) a new ChickenParticle.
        static void Main()
        {
            IRenderer renderer = new ConsoleRenderer(MaxRows, MaxCols);
            IParticleOperator particleOperator = new ParticleUpdater();

            int sleepTimeMs = 250;
            Engine engine = new Engine(renderer, particleOperator, sleepTimeMs);

            // Create a ChickenParticle (it will spawn other particles)
            MatrixCoords initialPosition = new MatrixCoords(MaxRows / 2, MaxCols / 2);
            MatrixCoords initialSpeed = new MatrixCoords(0, 0);
            Particle chickenParticle = new ChickenParticle(initialPosition, initialSpeed);
            engine.AddParticle(chickenParticle);

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