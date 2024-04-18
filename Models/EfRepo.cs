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
        return _context.Entertainers.FirstOrDefault(e => e.EntertainerID == id);
    }
}