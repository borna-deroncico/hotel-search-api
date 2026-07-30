using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelApi.Models;

namespace HotelApi.Controllers;

[ApiController]
[Route("api/hotels")]
public class HotelsController : ControllerBase
{
    private readonly AppDbContext _context;

    public HotelsController(AppDbContext context)
    {
        _context = context;
    }


    // READ ALL
    [HttpGet]
    public async Task<IActionResult> GetHotels()
    {
        var hotels = await _context.Hotels.ToListAsync();

        return Ok(hotels);
    }


    // READ ONE
    [HttpGet("{id}")]
    public async Task<IActionResult> GetHotel(int id)
    {
        var hotel = await _context.Hotels.FindAsync(id);

        if (hotel == null)
        {
            return NotFound();
        }

        return Ok(hotel);
    }


    // CREATE
    [HttpPost]
    public async Task<IActionResult> CreateHotel(Hotel hotel)
    {
        _context.Hotels.Add(hotel);

        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetHotel),
            new { id = hotel.id },
            hotel
        );
    }


    // UPDATE
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateHotel(int id, Hotel updatedHotel)
    {
        var hotel = await _context.Hotels.FindAsync(id);

        if (hotel == null)
        {
            return NotFound();
        }


        hotel.HotelName = updatedHotel.HotelName;
        hotel.Map = updatedHotel.Map;
        hotel.HotelPrice = updatedHotel.HotelPrice;

        await _context.SaveChangesAsync();

        return Ok(hotel);
    }


    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHotel(int id)
    {
        var hotel = await _context.Hotels.FindAsync(id);

        if (hotel == null)
        {
            return NotFound();
        }

        _context.Hotels.Remove(hotel);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}