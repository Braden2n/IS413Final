namespace Final.Models;

public interface IRepo
{
    // Methods used in the Controller for crud functionality
    IQueryable<Entertainer> Entertainers { get; }
    public Entertainer? EntertainerById(int id);
    public Entertainer NewEntertainer();
    public void UpdateEntertainer(Entertainer entertainer);
    public void DeleteEntertainer(Entertainer entertainer);
}