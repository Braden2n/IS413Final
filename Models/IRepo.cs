namespace Final.Models;

public interface IRepo
{
    IQueryable<Entertainer> Entertainers { get; }
    public Entertainer? EntertainerById(int id);
    public Entertainer NewEntertainer();
    public void UpdateEntertainer(Entertainer entertainer);
    public void DeleteEntertainer(Entertainer entertainer);
}