namespace UcakBiletAPI.Controllers.Models
{
    public class Flight : BaseFlight
    {
        
        public string? Name { get; set; }
        public string? Arrivetime { get; set; }
        public string? Starttime { get; set; }
        public DateTime Date { get; set; }
        public string? Start { get; set; }
        public string? End { get; set; }
        public Decimal Price { get; set; }
    }
}
