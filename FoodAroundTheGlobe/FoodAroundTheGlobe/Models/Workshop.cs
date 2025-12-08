namespace FoodAroundTheGlobe.Models
{
    public class Workshop
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int MaxParticipants { get; set; }
        public int Participants { get; set; }

    }
}


