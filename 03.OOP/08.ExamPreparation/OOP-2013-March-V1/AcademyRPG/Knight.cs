using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Knight : Character, IFighter
    {
        public Knight(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.HitPoints = 100;
            this.AttackPoints = 100;
            this.DefensePoints = 100;
        }

        public int AttackPoints { get; private set; }

        public int DefensePoints { get; private set; }

        // Knight should always pick the first available target to attack,
        // which is not neutral and does not belong to the same player as the Knight.
        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}