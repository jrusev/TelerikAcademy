using System;

namespace ParticleSystem
{
    class Program
    {
        private const int MaxRows = 60;
        private const int MaxCols = 60;

        // Implement a ParticleRepeller class. A ParticleRepeller is a Particle, which pushes other particles away from it
        // (i.e. accelerates them in a direction, opposite of the direction in which the repeller is).
        // The repeller has an effect only on particles within a certain radius (see Euclidean distance).
        static void Main()
        {
            IRenderer renderer = new ConsoleRenderer(MaxRows, MaxCols);
            IParticleOperator particleOperator = new ParticleUpdater();

            // Add particle repeller (appears as 'R' on the console)
            MatrixCoords repellerPosition = new MatrixCoords(MaxRows * 2 / 4, MaxCols * 2 / 4);
            MatrixCoords repellerSpeed = new MatrixCoords(0, 0);
            int repellerGravity = -4; // negative for antigravity
            ParticleRepeller repeller = new ParticleRepeller(repellerPosition, repellerSpeed, repellerGravity);

            // Use a field engine - derives from Engine, but can affect the speed of the particles,
            // the center of the field is the repeller

            int sleepTimeMs = 50;
            FieldEngine engine = new FieldEngine(renderer, particleOperator, sleepTimeMs, repeller);
            engine.AddParticle(repeller);

            // Add emmitter for free particles (appears as 'E' on the console)
            MatrixCoords emitterPosition = new MatrixCoords(MaxRows / 4, MaxCols / 4);
            MatrixCoords emitterSpeed = new MatrixCoords(4, 4);
            int particleLifeTicks = 30;
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