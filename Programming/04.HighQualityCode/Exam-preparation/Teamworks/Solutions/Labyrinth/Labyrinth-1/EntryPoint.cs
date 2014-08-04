namespace Labyrinth
{
    using System;

    class EntryPoint
    {
        static Playfield playfield = new Playfield();
        static Message message = new Message();
        static Scoreboard scores;
        static int moves = 0;

        static void Main(string[] args)
        {
            newGame();
            scores = new Scoreboard();
            String input = "";
            message.Move();
            while ((input = Console.ReadLine()) != "exit")
            {
                switch (input)
                {
                    case "top":
                        scores.ShowScoreboard();
                        break;
                    case "restart":
                        newGame();
                        break;
                    case "L":
                        if (!playfield.move(Direction.Left))
                        {
                            message.Invalid();
                        }
                        else
                        {
                            moves++;
                            playfield.print();
                        }
                        break;
                    case "U":
                        if (!playfield.move(Direction.Up))
                        {
                            message.Invalid();
                        }
                        else
                        {
                            moves++;
                            playfield.print();
                        }
                        break;
                    case "R":
                        if (!playfield.move(Direction.Right))
                        {
                            message.Invalid();
                        }
                        else
                        {
                            moves++;
                            playfield.print();
                        }
                        break;
                    case "D":
                        if (!playfield.move(Direction.Down))
                        {
                            message.Invalid();
                        }
                        else
                        {
                            moves++;
                            playfield.print();
                        }
                        break;
                    default:
                        message.Invalid();
                        break;
                }

                if (playfield.isWinning())
                {
                    message.Win(moves);
                    string name = Console.ReadLine();
                    try
                    {
                        scores.Add(name, moves);
                    }
                    finally
                    {

                    }

                    message.NewLine();
                    newGame();
                }

                message.Move();
            }

            Console.Write("Good Bye!");
            Console.ReadKey();
        }

        static void newGame()
        {
            message.Intro();
            playfield.reset();
            message.NewLine();
            playfield.print();
            moves = 0;
        }
    }
}