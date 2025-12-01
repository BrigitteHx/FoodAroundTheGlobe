namespace FoodAroundTheGlobe.Models
{
    public class Workshop
    {
            public int Id { get; set; }
            public string Titel { get; set; }
            public string Beschrijving { get; set; }
            public DateTime Datum { get; set; } = DateTime.Now;
            public int MaxAantalDeelnemers { get; set; } = 0;
    }
}