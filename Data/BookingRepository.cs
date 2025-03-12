using Microsoft.EntityFrameworkCore;
using CAGolfClubDB.Models;

namespace CAGolfClubDB.Data;

public class BookingRepository(CAGolfClubDBContext context) : Repository<Booking>(context)
{
    private readonly CAGolfClubDBContext _context = context;

    public IQueryable<Booking> GetFilteredBookings()
    {
        IQueryable<Booking> query = _context.Booking;

        return query;
    }

    public async Task<List<Booking>> GetBookingsAsync()
    {
        return await _context.Booking.OrderBy(p => p.Date).ToListAsync();
    }


    public async Task<bool> IsSlotAvailableAsync(string slot, DateTime date)
    {
        var slotAvailable = await _context.Booking
            .Where(e => e.Date.Date == date.Date && e.Slot == slot)
            .FirstOrDefaultAsync();
        return slotAvailable == null;
    }

    public async Task<bool> IsPlayerAlreadyBookedAsync(int playerId, DateTime date)
    {
        var alreadyBooked = await _context.Booking
            .Where(e => e.PlayerId == playerId && e.Date.Date == date.Date)
            .FirstOrDefaultAsync();
        return alreadyBooked != null;
    }

    public async Task AddBookingAsync(Booking booking, List<BookingPlayer> bookingPlayers)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            _context.Booking.Add(booking);
            await _context.SaveChangesAsync();

            foreach (var bookingPlayer in bookingPlayers)
            {
                bookingPlayer.BookingId = booking.Id;
                _context.BookingPlayer.Add(bookingPlayer);
            }

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw new Exception("Error adding booking", ex);
        }
    }

    public List<string> GenerateAvailableTimes()
    {
        var times = new List<string>();
        var slotTime = new DateTime(1, 1, 1, 0, 0, 0);
        var currentTime = DateTime.Now;

        while (slotTime.Hour != 23 || slotTime.Minute != 45)
        {
            times.Add(slotTime.ToString("HH:mm"));
            slotTime = slotTime.AddMinutes(15); // Advances by 15 minutes
        }

        slotTime.AddMinutes(15);
        times.Add(slotTime.ToString("HH:mm"));

        return times;
    }
}
