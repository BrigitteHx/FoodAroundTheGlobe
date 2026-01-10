using FoodAroundTheGlobe.Models;
using System;

namespace FoodAroundTheGlobe.Models
{
    public class Workshops
    {
        public int Id { get; set; }
        public string NameWs { get; set; } = string.Empty;
        public string DescriptionWs { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
        public int MaxParticipants { get; set; }
    }
}


