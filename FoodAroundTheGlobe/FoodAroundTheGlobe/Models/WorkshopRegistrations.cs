using System;
using System.ComponentModel.DataAnnotations;
using FoodAroundTheGlobe.Data;

namespace FoodAroundTheGlobe.Models
{
    public class WorkshopRegistrations
    {

        public int Id { get; set; }
        public int WorkshopId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string ParticipantEmail { get; set; } = string.Empty;
        public string? ParticipantName { get; set; }
        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
    }
}
