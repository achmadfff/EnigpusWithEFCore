using EnigpusEFCore.Entities;

namespace EnigpusEFCore.Repositories;

public class MagazineRepository : IMagazineRepository
{
    private readonly EnigpusDBContext _enigpusDbContext;

    public MagazineRepository(EnigpusDBContext enigpusDbContext)
    {
        _enigpusDbContext = enigpusDbContext;
    }

    public void AddMagazine(Magazine magazine)
    {
        _enigpusDbContext.Magazines.Add(magazine);
    }

    public Magazine? SearchMagazineByTitle(string title)
    {
        return _enigpusDbContext.Magazines.FirstOrDefault(magazine => magazine.Title.Equals(title));
    }

    public Magazine? SearchMagazineById(int id)
    {
        return _enigpusDbContext.Magazines.FirstOrDefault(magazine => magazine.Id.Equals(id));
    }

    public void DeleteMagazine(Magazine magazine)
    {
        _enigpusDbContext.Magazines.Remove(magazine);
    }

    public List<Magazine> GetAllMagazine()
    {
        return _enigpusDbContext.Magazines.ToList();
    }

    public void UpdateMagazine(Magazine magazine)
    {
        _enigpusDbContext.Magazines.Update(magazine);
    }
}