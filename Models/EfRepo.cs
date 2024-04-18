namespace Final.Models;

public class EfRepo : IRepo
{
    // DBContext object for database usage
    private readonly ApplicationDbContext _context;
    public EfRepo(ApplicationDbContext context)
    {
        _context = context;
    }

    public IQueryable<Entertainer> Entertainers => _context.Entertainers;

    public Entertainer? EntertainerById(int id)
    {
        // Gets a possible entertainer or null
        return _context.Entertainers.FirstOrDefault(e => e.EntertainerId == id);
    }

    public Entertainer NewEntertainer()
    {
        // Gets the maximum ID currently in use (or 0 if empty)
        var maxId = _context.Entertainers.Max(e => (int?)e.EntertainerId) ?? 0;
        // Adds 1 for the next id
        var nextId = maxId + 1;
        // New Entertainer with the id set
        var entertainer = new Entertainer
        {
            EntertainerId = nextId
        };
        return entertainer;
    }

    public void UpdateEntertainer(Entertainer entertainer)
    {
        // Determines whether the entertainer needs to be updated or added (already exists)
        var exists = _context.Entertainers.Any(e => e.EntertainerId == entertainer.EntertainerId);
        if (exists)
        {
            // Updating
            _context.Entertainers.Update(entertainer);
        }
        else
        {
            // Adding
            _context.Entertainers.Add(entertainer);
        }
        _context.SaveChanges();
    }

    public void DeleteEntertainer(Entertainer entertainer)
    {
        // Removes entertainer and saves changes
        _context.Entertainers.Remove(entertainer);
        _context.SaveChanges();
    }
}