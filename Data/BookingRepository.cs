using Microsoft.EntityFrameworkCore;
using CAGolfClubDB.Models;

namespace CAGolfClubDB.Data;

public class BookingRepository : Repository<Booking>
{
    private readonly CAGolfClubDBContext _context;

    public IQueryable<Booking> GetFilteredBookings()
    {
        IQueryable<Booking> query = _context.Booking;

        return query;
    }

    public BookingRepository(CAGolfClubDBContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Booking>> GetBookingsAsync()
    {
        return await _context.Booking.OrderBy(p => p.Date).ToListAsync();
    }
}
