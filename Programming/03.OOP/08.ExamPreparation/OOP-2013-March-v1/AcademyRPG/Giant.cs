using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Giant : Character, IFighter, IGatherer
    {
        private const int Neutral = 0;
        private bool attackModified = false;

        public Giant(string name, Point position)
            : base(name, position, Giant.Neutral)
        {
            this.HitPoints = 200;
            this.AttackPoints = 150;
            this.DefensePoints = 80;
        }

        public int AttackPoints { get; private set; }

        public int DefensePoints { get; private set; }

        // When attacking, the Giant should pick the first available target, which is not neutral.
        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != Giant.Neutral)
                {
                    return i;
                }
            }

            return -1;
        }

        // The Giant should also be able to gather Stone resources.
        // When a Giant gathers such a resource, his AttackPoints are permanently increased by 100.
        // This should only work once. 
        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone)
            {
                if (!this.attackModified)
                {
                    this.attackModified = true;
                    this.AttackPoints += 100;
                }

                return true;
            }

            return false;
        }
    }
}
