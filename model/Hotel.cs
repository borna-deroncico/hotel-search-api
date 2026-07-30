namespace HotelApi.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("hotels")]
    public class Hotel
    {
        public int id { get; set; }
        public string HotelName { get; set; }
        public string Map { get; set; }
        public double HotelPrice { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}