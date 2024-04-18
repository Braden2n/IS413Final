namespace Final.Models;

public interface IRepo
{
    IQueryable<Entertainer> Entertainers { get; }
    public Entertainer? EntertainerById(int id);
}