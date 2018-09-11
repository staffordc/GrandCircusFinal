namespace GCFinal.Domain.Models

{
    public class Day
    {
        public double maxtemp_c { get; set; }
        public decimal maxtemp_f { get; set; }
        public double mintemp_c { get; set; }
        public decimal mintemp_f { get; set; }
        public double avgtemp_c { get; set; }
        public decimal avgtemp_f { get; set; }
        public double maxwind_mph { get; set; }
        public double maxwind_kph { get; set; }
        public double totalprecip_mm { get; set; }
        public double totalprecip_in { get; set; }
        public double avgvis_km { get; set; }
        public int avgvis_miles { get; set; }
        public int avghumidity { get; set; }
        public Condition condition { get; set; }
        public int uv { get; set; }
    }
}
