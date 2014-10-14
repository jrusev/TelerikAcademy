using System.ComponentModel.DataAnnotations;

namespace BullsCows.WebAPI.Models
{
    // { "name": "The Empire strikes back!", "number": "5976" }
    public class CreateGameModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Number { get; set; }
    }
}