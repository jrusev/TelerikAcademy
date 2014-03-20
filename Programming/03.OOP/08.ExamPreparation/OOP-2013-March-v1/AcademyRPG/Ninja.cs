using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Ninja : Character, IFighter, IGatherer
    {
        public Ninja(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.HitPoints = 1;
            this.AttackPoints = 0;
            // The Ninja should be invulnerable – it should not be able to be destroyed by other objects.
            this.DefensePoints = int.MaxValue;
        }

        public int AttackPoints { get; private set; }

        public int DefensePoints { get; private set; }

        // Ninja should always attack the target, which is not neutral,
        // does not belong to the same player, and has the highest HitPoints of all the available targets.
        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            int targetIndex = -1;
            for (int i = 0; i < availableTargets.Count; i++)
            {
                int maxHitPoints = int.MinValue;                
                if (availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0)
                {
                    if (availableTargets[i].HitPoints > maxHitPoints)
                    {
                        targetIndex = i;
                        maxHitPoints = availableTargets[i].HitPoints;
                    }                    
                }
            }

            return targetIndex;
        }

        // The Ninja should be able to gather stone and lumber resources.
        // For each lumber resource the Ninja has gathered, its AttackPoints should increase by the resource’s quantity.
        // For each stone resource the Ninja has gathered, its AttackPoints should increase by the resource’s quantity multiplied by 2. 
        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Lumber)
            {
                this.AttackPoints += resource.Quantity;
                return true;
            }
            else if (resource.Type == ResourceType.Stone)
            {
                this.AttackPoints += resource.Quantity * 2;
                return true;
            }
            else
            {
                return false;
            }           
        }
    }
}
