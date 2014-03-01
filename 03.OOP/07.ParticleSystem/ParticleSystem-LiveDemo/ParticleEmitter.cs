using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public class ParticleEmitter : Particle
    {
        const int MaxElementsPerUpdateCount = 5;
        const int MaxSpeedPerCoordinate = 2;

        protected Random randomGenerator;

        public ParticleEmitter(MatrixCoords position, MatrixCoords speed, Random randomGenerator) :
            base(position, speed)
        {
            this.randomGenerator = randomGenerator;
        }

        public override char[,] GetImage()
        {
            return new char[,] { { (char)1 } };
        }

        public override IEnumerable<Particle> Update()
        {
            IEnumerable<Particle> objectsSoFar = base.Update();
            List<Particle> allGeneratedObjects = new List<Particle>();

            int objectsToCreateCount = this.randomGenerator.Next(MaxElementsPerUpdateCount + 1);

            for (int i = 0; i < objectsToCreateCount; i++)
            {
                GetRandomParticle(allGeneratedObjects);
            }

            allGeneratedObjects.AddRange(objectsSoFar);

            return allGeneratedObjects;
        }

        protected virtual void GetRandomParticle(List<Particle> allGeneratedObjects)
        {
            var createdSpeed = GetRandomCoords();

            while (createdSpeed.Row == 0 && createdSpeed.Col == 0)
            {
                createdSpeed = GetRandomCoords();
            }

            allGeneratedObjects.Add(
                this.GetNewParticle(this.Position, createdSpeed)
                );
        }

        protected virtual Particle GetNewParticle(MatrixCoords position, MatrixCoords speed)
        {
            return new Particle(position, speed);
        }

        protected MatrixCoords GetRandomCoords()
        {
            int randomSpeedRow =
                this.randomGenerator.Next(-MaxSpeedPerCoordinate, MaxSpeedPerCoordinate + 1);
            int randomSpeedCol =
                this.randomGenerator.Next(-MaxSpeedPerCoordinate, MaxSpeedPerCoordinate + 1);

            var createdSpeed = new MatrixCoords(
                    randomSpeedRow,
                    randomSpeedCol
                );
            return createdSpeed;
        }
    }
}
