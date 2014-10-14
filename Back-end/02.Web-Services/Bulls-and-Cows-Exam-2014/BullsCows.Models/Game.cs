using System;
using System.Collections.Generic;

namespace BullsCows.Models
{
    public class Game
    {
        public Game()
        {
            this.BlueGuesses = new HashSet<Guess>();
            this.RedGuesses = new HashSet<Guess>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string BlueId { get; set; }

        public virtual ApplicationUser Blue { get; set; }

        // The creator user is marked as red player
        public string RedId { get; set; }

        public virtual ApplicationUser Red { get; set; }

        public GameState GameState { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual ICollection<Guess> BlueGuesses { get; set; }

        public virtual ICollection<Guess> RedGuesses { get; set; }

        public string RedNumber { get; set; }

        public string BlueNumber { get; set; }
    }
}
