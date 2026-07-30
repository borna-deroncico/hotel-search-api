namespace HotelApi.Models;

public class SearchRequest
{
    public int Price { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }
}