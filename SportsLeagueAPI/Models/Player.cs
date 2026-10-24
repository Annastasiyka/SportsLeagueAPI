using System.ComponentModel.DataAnnotations;

namespace SportsLeagueAPI.Models
{
    public class Player
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Position { get; set; }
        public int Number { get; set; }

        public int TeamId { get; set; }
        public Team? Team { get; set; }
    }
}