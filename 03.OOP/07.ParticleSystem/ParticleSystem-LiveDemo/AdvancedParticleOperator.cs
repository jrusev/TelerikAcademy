using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public class AdvancedParticleOperator : ParticleUpdater
    {
        private List<Particle> currentTickParticles = new List<Particle>();
        private List<ParticleAttractor> currentTickAttractors = new List<ParticleAttractor>();

        public override IEnumerable<Particle> OperateOn(Particle p)
        {
            var potentialAttractor = p as ParticleAttractor;
            if (potentialAttractor != null)
            {
                currentTickAttractors.Add(potentialAttractor);
            }
            else
            {
                this.currentTickParticles.Add(p);
            }
            
            return base.OperateOn(p);
        }

        public override void TickEnded()
        {
            foreach (var attractor in this.currentTickAttractors)
            {
                foreach (var particle in this.currentTickParticles)
                {
                    var currParticleToAttractorVector = attractor.Position - particle.Position;

                    int pToAttrRow = currParticleToAttractorVector.Row;
                    pToAttrRow = DecreaseVectorCoordToPower(attractor, pToAttrRow);

                    int pToAttrCol = currParticleToAttractorVector.Col;
                    pToAttrCol = DecreaseVectorCoordToPower(attractor, pToAttrCol);

                    var currAcceleration = new MatrixCoords(pToAttrRow, pToAttrCol);

                    particle.Accelerate(currAcceleration);
                }
            }

            this.currentTickParticles.Clear();
            this.currentTickAttractors.Clear();

            base.TickEnded();
        }

        private static int DecreaseVectorCoordToPower(ParticleAttractor attractor, int pToAttrCoord)
        {
            if (Math.Abs(pToAttrCoord) > attractor.AttractionPower)
            {
                pToAttrCoord = (pToAttrCoord / (int)Math.Abs(pToAttrCoord)) * attractor.AttractionPower;
            }
            return pToAttrCoord;
        }
    }
}
