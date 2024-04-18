namespace Final.Models;

public class EfRepo : IRepo
{
    private readonly ApplicationDbContext _context;
    public EfRepo(ApplicationDbContext context)
    {
        _context = context;
    }

    public IQueryable<Entertainer> Entertainers => _context.Entertainers;

    public Entertainer? EntertainerById(int id)
    {
        return _context.Entertainers.FirstOrDefault(e => e.EntertainerId == id);
    }

    public Entertainer NewEntertainer()
    {
        var maxId = _context.Entertainers.Max(e => (int?)e.EntertainerId) ?? 0;
        var nextId = maxId + 1;
        var entertainer = new Entertainer
        {
            EntertainerId = nextId
        };
        return entertainer;
    }

    public void UpdateEntertainer(Entertainer entertainer)
    {
        var exists = _context.Entertainers.Any(e => e.EntertainerId == entertainer.EntertainerId);
        if (exists)
        {
            _context.Entertainers.Update(entertainer);
        }
        else
        {
            _context.Entertainers.Add(entertainer);
        }
        _context.SaveChanges();
    }

    public void DeleteEntertainer(Entertainer entertainer)
    {
        _context.Entertainers.Remove(entertainer);
        _context.SaveChanges();
    }
}