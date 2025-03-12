using Microsoft.EntityFrameworkCore;
using CAGolfClubDB.Models;

namespace CAGolfClubDB.Data;

public class PlayerRepository : Repository<Player>
{
    private readonly CAGolfClubDBContext _context;

    public PlayerRepository(CAGolfClubDBContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Player>> GetPlayersAsync()
    {
        return await _context.Player.OrderBy(p => p.Name).ToListAsync();
    }

    public async Task<List<string>> GetDistinctGendersAsync()
    {
        return await _context.Player
            .Select(p => p.Gender)
            .Distinct()
            .ToListAsync();
    }

    public IQueryable<Player> GetFilteredPlayers(string nameFilter, string genderFilter, string handicapFilter)
    {
        IQueryable<Player> query = _context.Player;

        if (!string.IsNullOrEmpty(nameFilter))
        {
            query = query.Where(c => c.Name.Contains(nameFilter, StringComparison.CurrentCultureIgnoreCase));
        }

        if (genderFilter != "All")
        {
            query = query.Where(c => c.Gender == genderFilter);
        }

        if (handicapFilter != "All")
        {
            query = handicapFilter switch
            {
                "10" => query.Where(c => c.Handcap <= 10),
                "11-20" => query.Where(c => c.Handcap > 10 && c.Handcap < 20),
                "20" => query.Where(c => c.Handcap >= 20),
                _ => query
            };
        }

        return query;
    }
}
