namespace FoodAroundTheGlobe.Models
{
    public class Workshops
    {
        public int Id { get; set; }
        public string NameWs { get; set; }
        public string DescriptionWs { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int MaxParticipants { get; set; }

    }
}


