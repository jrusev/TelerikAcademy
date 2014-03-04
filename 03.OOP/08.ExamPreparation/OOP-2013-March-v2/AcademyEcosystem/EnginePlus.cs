using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
    public class EnginePlus : Engine
    {
        protected override void ExecuteBirthCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "wolf":
                    {
                        // birth wolf <name> <position>
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        this.AddOrganism(new Wolf(name, position));
                        break;
                    }
                case "boar":
                    {
                        // birth boar <name> <position>
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        this.AddOrganism(new Boar(name, position));
                        break;
                    }
                //case "tree":
                //    {
                //        Point position = Point.Parse(commandWords[2]);
                //        this.AddOrganism(new Tree(position));
                //        break;
                //    }
                //case "bush":
                //    {
                //        Point position = Point.Parse(commandWords[2]);
                //        this.AddOrganism(new Bush(position));
                //        break;
                //    }
                default:
                    base.ExecuteBirthCommand(commandWords);
                    break;
            }            
        }
    }
}
