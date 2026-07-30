using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelApi.Models;

namespace HotelApi.Controllers;

[ApiController]
[Route("api/search")]
public class SearchController : ControllerBase
{
    private readonly AppDbContext _context;

    public SearchController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> SearchHotels(SearchRequest request)
    {
        double maxDistanceKm = 10; // search radius

        var hotels = await _context.Hotels
            .Where(h => h.HotelPrice <= request.Price)
            .ToListAsync();

        var nearbyHotels = hotels
            .Where(h =>
            {
                double distance = CalculateDistance(
                    request.Latitude,
                    request.Longitude,
                    h.Latitude,
                    h.Longitude
                );

                return distance <= maxDistanceKm;
            })
            .ToList();

        return Ok(nearbyHotels);
    }


    private double CalculateDistance(
        double userLat,
        double userLon,
        double hotelLat,
        double hotelLon)
    {
        const double earthRadius = 6371; // km

        double latDifference = DegreesToRadians(hotelLat - userLat);
        double lonDifference = DegreesToRadians(hotelLon - userLon);

        double a =
            Math.Sin(latDifference / 2) * Math.Sin(latDifference / 2) +
            Math.Cos(DegreesToRadians(userLat)) *
            Math.Cos(DegreesToRadians(hotelLat)) *
            Math.Sin(lonDifference / 2) *
            Math.Sin(lonDifference / 2);

        double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        return earthRadius * c;
    }


    private double DegreesToRadians(double degrees)
    {
        return degrees * Math.PI / 180;
    }
}