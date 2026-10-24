using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text.Json.Serialization;

namespace SportsLeagueAPI.Models
{
    public class Team
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string City { get; set; }
        public string CoachName { get; set; }
        public int FoundedYear { get; set; }

        [JsonIgnore] 
        public ICollection<Player>? Players { get; set; }
    }
}