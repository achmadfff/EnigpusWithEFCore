using EnigpusEFCore.Entities;

namespace EnigpusEFCore.Repositories;

public class NovelRepository : INovelRepository
{
    private readonly EnigpusDBContext _enigpusDbContext;

    public NovelRepository(EnigpusDBContext enigpusDbContext)
    {
        _enigpusDbContext = enigpusDbContext;
    }

    public void AddNovel(Novel novel)
    {
        _enigpusDbContext.Novels.Add(novel);
    }

    public Novel? SearchNovelByTitle(string title)
    {
        return _enigpusDbContext.Novels.FirstOrDefault(novel => novel.Title.Equals(title));
    }

    public Novel? SearchNovelById(int id)
    {
        return _enigpusDbContext.Novels.FirstOrDefault(novel => novel.Id.Equals(id));
    }

    public void DeleteNovel(Novel novel)
    {
        _enigpusDbContext.Novels.Remove(novel);
    }

    public List<Novel> GetAllNovel()
    {
        return _enigpusDbContext.Novels.ToList();
    }

    public void UpdateNovel(Novel novel)
    {
        _enigpusDbContext.Novels.Update(novel);
    }
}