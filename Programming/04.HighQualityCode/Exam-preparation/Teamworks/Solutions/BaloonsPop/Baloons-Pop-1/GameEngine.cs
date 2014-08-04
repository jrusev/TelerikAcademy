namespace PoppingBaloons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GameEngine
    {
        private BaloonMatrix baloonMatrix;
        private List<Tuple<string, int>> scoreboard;

        public GameEngine()
        {
            this.baloonMatrix = new BaloonMatrix();
            this.scoreboard = new List<Tuple<string, int>>();
        }

        public void ParseCommand(string input)
        {
            if (input == "exit")
            {
                Console.WriteLine("Thanks for playing!!");
                Environment.Exit(0);
            }
            else
            {
                if (input == "restart")
                {
                    this.Restart();
                }
                else
                {
                    if (input.Length == 3)
                    {
                        if (input == "top")
                        {
                            this.DisplayScoreboard();
                        }
                        else
                        {
                            // check input validation
                            int row, col;
                            bool validRow = int.TryParse(input.Remove(1), out row);
                            bool validCOl = int.TryParse(input.Remove(0, 1), out col);
                            if (validRow && validCOl)
                            {
                                this.ExecuteCommand(row, col);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Unknown Command");
                    }
                }
            }
        }

        private void DisplayScoreboard()
        {
            if (this.scoreboard.Count == 0)
            {
                Console.WriteLine("The scoreboard is empty");
            }
            else
            {
                Console.WriteLine("Top performers:");
                Action<Tuple<string, int>> print = elem => { Console.WriteLine(elem.Item1 + "  " + elem.Item2.ToString() + " turns "); };
                this.scoreboard.ForEach(print);
            }
        }

        private void ExecuteCommand(int row, int col)
        {
            bool gameOver = false;
            if (row > 5)
            {
                Console.WriteLine("Indexes too big");
            }
            else
            {
                gameOver = this.baloonMatrix.PopBaloon(row + 1, col + 1);
            }

            if (gameOver)
            {
                Console.WriteLine("Congratulations!!You popped all the baloons in" + this.baloonMatrix.Turns + "moves!");
                this.UpdateScoreboard();
            }            
        }

        private void UpdateScoreboard()
        {
            if (this.scoreboard.Count < 5)
            {
                this.AddScore(this.baloonMatrix.Turns);
                return;
            }
            else
            {
                if (this.scoreboard.ElementAt<Tuple<string, int>>(4).Item2 >= this.baloonMatrix.Turns)
                {
                    this.AddScore(this.baloonMatrix.Turns);

                    // if the new name replaces one of the old ones, remove the old one
                    this.scoreboard.RemoveRange(4, 1);
                }
            }

            this.scoreboard.Sort((p1, p2) => p1.Item2.CompareTo(p2.Item2));
            this.Restart();
        }

        private void AddScore(int turns)
        {
            // get the player name and add a tuple to the scoreboard
            Console.WriteLine("Enter Name:");
            string name = Console.ReadLine();
            var score = Tuple.Create<string, int>(name, turns);
            this.scoreboard.Add(score);
        }

        private void Restart()
        {
            this.baloonMatrix = new BaloonMatrix();
        }
    }
}
