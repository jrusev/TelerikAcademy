using System;

namespace ParticleSystem
{
    class Program
    {
        private const int MaxRows = 40;
        private const int MaxCols = 80;

        // Create a ChaoticParticle class, which is a Particle, randomly changing its movement (Speed).
        static void Main()
        {
            IRenderer renderer = new ConsoleRenderer(MaxRows, MaxCols);
            IParticleOperator particleOperator = new ParticleUpdater();

            Engine engine = new Engine(renderer, particleOperator);

            // Create a ChaoticParticle
            MatrixCoords initialPosition = new MatrixCoords(MaxRows / 2, MaxCols / 2);
            MatrixCoords initialSpeed = new MatrixCoords(0, 0);
            Particle chaoticParticle = new ChaoticParticle(initialPosition, initialSpeed);
            engine.AddParticle(chaoticParticle);

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