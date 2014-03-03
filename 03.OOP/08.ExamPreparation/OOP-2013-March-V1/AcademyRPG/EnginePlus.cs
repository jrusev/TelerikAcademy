using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class EnginePlus : Engine
    {
        public EnginePlus()
            : base()
        {
        }

        public override void ExecuteCreateObjectCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "knight":
                    {
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        int owner = int.Parse(commandWords[4]);
                        this.AddObject(new Knight(name, position, owner));
                        break;
                    }
                //case "guard":
                //    {
                //        string name = commandWords[2];
                //        Point position = Point.Parse(commandWords[3]);
                //        int owner = int.Parse(commandWords[4]);
                //        this.AddObject(new Guard(name, position, owner));
                //        break;
                //    }
                //case "tree":
                //    {
                //        int size = int.Parse(commandWords[2]);
                //        Point position = Point.Parse(commandWords[3]);
                //        this.AddObject(new Tree(size, position));
                //        break;
                //    }
                default:
                    base.ExecuteCreateObjectCommand(commandWords);
                    break;
            }            
        }
    }
}
